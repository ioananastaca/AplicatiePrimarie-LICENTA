using System.Collections.Generic;
using Licenta.Models;
using System.Linq;
using System.Web.Mvc;

namespace Licenta.Controllers
{
    public class ProgramariController : Controller
    {
        //private DbLicentaEntities context;
        private ProgramareCasatorieAdmin casatorieAdminModel;
        private AudientaAdmin audientaAdminModel;

        public ProgramariController()
        {
            audientaAdminModel = new AudientaAdmin();
            casatorieAdminModel = new ProgramareCasatorieAdmin();
           // context = new DbLicentaEntities();
        }
        // GET: Programari
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult AddPVStareCivila(string message)
        {
            var programareCasatorie = new ProgramareCasatorie();
            programareCasatorie.BookedMarriages = new List<KeyValuePair<string, string>>();
            using (var context = new DbLicentaEntities())
            {
                var x = context.Marriage.ToList();
                foreach (var item in x)
                {
                    programareCasatorie.BookedMarriages.Add(new KeyValuePair<string, string>(item.Date,item.Hour));
                }
            }

            if (!string.IsNullOrEmpty(message))
            {
                programareCasatorie.SuccessMessage = message;
            }

            return View("_CasatorieUser", programareCasatorie);
        }
    
        public ActionResult SaveMarriage(ProgramareCasatorie programare)
        {
            if (!ModelState.IsValid)
            {
                return View("_CasatorieUser", programare);
            }
            else
            {
                using (var context = new DbLicentaEntities())
                {
                    var appSession = AppSession.Instance();
                    context.Marriage.Add(new Marriage
                    {
                        Date = programare.Date,
                        Hour = programare.Hour,
                        HusbandName = programare.HusbandName,
                        HusbandCNP = programare.HusbandCNP,
                        WifeName = programare.WifeName,
                        WifeCNP = programare.WifeCNP,
                        EmailAdress = programare.EmailAdress,
                        PhoneNumber = programare.PhoneNumber,
                        UserId = appSession.LoggedUser.Id

                    });
                    context.SaveChanges();
                }
                //return View("_CasatorieUser", new ProgramareCasatorie {SuccessMessage = "Programare trimisa"});
                ModelState.Clear();
                return AddPVStareCivila("Programare trimisa");
            }
            
        }
        //admin use
        public ActionResult ProgramareCasatorieTable()
        {
            using (var context = new DbLicentaEntities())
            {
                casatorieAdminModel.marriages = context.Marriage.ToList();
            }
            return PartialView("_CasatorieAdminTable",casatorieAdminModel.marriages);
        }



        //pt audienta
        public ActionResult SaveAudienta(Audienta audienta)
        {
            if (!ModelState.IsValid)
            {
                return View("_AudientaUser",audienta);
            }
            else
            {
                using (var context = new DbLicentaEntities())
                {
                    var appSession = AppSession.Instance();
                    context.Audience.Add(new Audience
                    {
                        Nume = audienta.Nume,
                        Telefon = audienta.Telefon,
                        SolicitareLa = audienta.SolicitareLa,
                        Motiv = audienta.Motiv,
                        UserId = appSession.LoggedUser.Id

                    });

                    context.SaveChanges();
                }

                ModelState.Clear();
                return AddPVAudientaUser("Audienta inregistrata");
            }
            
        }
        public ActionResult SaveMentiuni(int audienceId, string mentiune)
        {
            using (var context = new DbLicentaEntities())
            {
                var audienceToEdit= context.Audience.Where(x => x.IdAudienta == audienceId).FirstOrDefault();
                audienceToEdit.Mentiuni = mentiune;
                context.SaveChanges();
            }
            return Index();
        }

        public ActionResult AddPVAudientaUser(string message)
        {
            Audienta audienta = new Audienta();

            if (!string.IsNullOrEmpty(message))
            {
                audienta.SuccesMesaj = message;
            }

            return View("_AudientaUser",audienta);
        }


        //admin audienta
        public ActionResult AudientaTable()
        {
            using (var context = new DbLicentaEntities())
            {
                audientaAdminModel.audiences = context.Audience.ToList();
            }
            return PartialView("_AudientaAdminTable", audientaAdminModel.audiences);
        }


        public ActionResult DeleteAudience(int audienceId)
        {
            using (var context = new DbLicentaEntities())
            {
                var audienceToRemove = context.Audience.Where(x => x.IdAudienta == audienceId).FirstOrDefault();
                context.Audience.Remove(audienceToRemove);
                context.SaveChanges();
                audientaAdminModel.audiences = context.Audience.ToList();
            }

            return Index();
        }

      

        //admin use
        public ActionResult DeleteMarriage(int marriageId)
        {
            using (var context = new DbLicentaEntities())
            {
                var marriageToRemove = context.Marriage.Where(x => x.Id == marriageId).FirstOrDefault();
                context.Marriage.Remove(marriageToRemove);
                context.SaveChanges();
                casatorieAdminModel.marriages = context.Marriage.ToList();
            }

            return Index();
        }

        //for documents selection
        public ActionResult getDocuments()
        {
            return PartialView("_Documents");
        }
        public ActionResult getPageLinks()
        {
            return PartialView("_PageLinks");
        }
    }




}