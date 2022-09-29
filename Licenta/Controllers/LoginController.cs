using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Licenta.Models;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities;

namespace Licenta.Controllers
{
    public class LoginController : Controller

    {
        
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Message = "Autentificare";

            return View();
        }

        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {

            
            using(DbLicentaEntities db=new DbLicentaEntities())
            {
                //pt parola
                SHA256 sha256 = SHA256Managed.Create();
                UTF8Encoding objUtf8 = new UTF8Encoding();
                var hashValue = sha256.ComputeHash(objUtf8.GetBytes(login.Password));
                var hashedPassword = Encoding.Default.GetString(hashValue);


                var userDetails = db.User.Where(x => x.EmailAddress == login.EmailAddress
                    && x.Password==hashedPassword).FirstOrDefault();

                if (userDetails == null)
                {
                    
                    login.LoginErrorMessage = "Adresa de mail sau parola sunt gresite!";
                    return View("Index",login);
                }
                else
                {
                //    AppSession.IsUserLogged = true;
                //    AppSession.LoggedUser = userDetails;
                    AppSession.Login(userDetails);
                    return RedirectToAction("Index", "Home");
                }
            }
            }
        }

        public ActionResult LogOut()
        {
        
            AppSession.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}