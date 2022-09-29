using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Licenta.Models;

namespace Licenta.Controllers
{
    public class CreateAccountController : Controller
    {
        public CreateAccountController()
        {
        }
        // GET: CreateAccount
        public ActionResult Index()
        {
            return View(new CreateAccount());
        }

        public ActionResult Create(CreateAccount accountModel)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", accountModel);
            }
            else
            {
                SHA256 sha256 = SHA256Managed.Create();
                UTF8Encoding objUtf8 = new UTF8Encoding();
                var hashValue = sha256.ComputeHash(objUtf8.GetBytes(accountModel.Password));
                using (var context = new DbLicentaEntities())
                {

                    context.User.Add(new User
                    {
                        Password = Encoding.Default.GetString(hashValue),
                        //Password=accountModel.Password,
                        EmailAddress = accountModel.EmailAddress,
                        IsAdmin = false
                    });
                    context.SaveChanges();
                }
                accountModel.AccountCreated = true;
                return View("Index", accountModel);
            }
           
        }
    }
}