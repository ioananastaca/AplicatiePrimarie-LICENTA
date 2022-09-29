using System.Collections.Generic;
using Licenta.Models;
using System.Linq;
using System.Security;
using System.Web.Mvc;

namespace Licenta.Controllers
{
    public class SesizareController : Controller
    {
        private SesizareAdmin sesizareAdminModel;
        private static string resultMessage;
        public SesizareController()
        {
            sesizareAdminModel = new SesizareAdmin();
        }
        // GET: Sesizare
        public ActionResult Index()
        {
            resultMessage = string.Empty;
            return View();
        }
        //for User use
        public ActionResult SesizareUser(Sesizare sesizare)
        {
            if (!ModelState.IsValid)
            {
                return View("_SesizareUser", sesizare);
            }
            else
            {
                var appSession = AppSession.Instance();
                if (appSession.IsUserLogged)
                {
                    using (var context = new DbLicentaEntities())
                    {
                        context.Report.Add(new Report
                        {
                            TitlulSesizarii = sesizare.TitluSesizare,
                            Adresa = sesizare.Adresa,
                            Descriere = sesizare.Descriere,
                            EsteUrgenta = sesizare.esteUrgenta,
                            UserId = appSession.LoggedUser.Id

                        });
                        context.SaveChanges();

                    }

                }
                sesizare.Message = "Sesizare dumnevoastra este trimisa!";
                ModelState.Clear();
                return View("Index", sesizare);

            }

        }

        //for Admin use

        public ActionResult SesizareAdminTable()
        {
            using (var context = new DbLicentaEntities())
            {
                sesizareAdminModel.Reports = context.Report.ToList();
            }
            return PartialView("_SesizareAdminTable", sesizareAdminModel.Reports);
        }

        public ActionResult SesizareResult()
        {
            return PartialView("_SesizareResult", resultMessage);
        }
        public ActionResult SesizareAdmin()
        {
            return PartialView("_SesizareAdmin", sesizareAdminModel);
        }

        public ActionResult ResolveReports(List<Report> reports)
        {
            var reps = reports.Select(x => x.Id).ToList();

            using (var context = new DbLicentaEntities())
            {
                var dbReports = context.Report
                    .Where(x=>reps.Contains(x.Id)).ToList();

                foreach (var report in dbReports)
                {
                    report.IsResolved = reports.Where(x => x.Id == report.Id).Select(x => x.IsResolved).First();
                }

                sesizareAdminModel.Reports = context.Report.ToList();
                resultMessage = "Sesizare rezolvata!";

                context.SaveChanges();
            }
            return View("Index");
        }
        

        public ActionResult loaddata()
        {
            using (DbLicentaEntities context = new DbLicentaEntities())
            {
                var data = context.Report.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}