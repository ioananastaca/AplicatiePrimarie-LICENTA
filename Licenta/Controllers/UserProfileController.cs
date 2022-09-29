using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Licenta.Models;
using System.Text.Json;

namespace Licenta.Controllers
{
    public class UserProfileController : Controller
    {
        private UserActivity model;
        public UserProfileController()
        {
            var model=new UserActivity();
        }
        // GET: UserProfile
        public ActionResult Index()
        {
            var model=new UserActivity();
            var appSession = AppSession.Instance();
            //return View(new List<Audience>());
            using (var context = new DbLicentaEntities())
            {
                model.Audiences = context.Audience.Where(x => x.UserId == appSession.LoggedUser.Id).ToList();
                model.Reports= context.Report.Where(x => x.UserId == appSession.LoggedUser.Id).ToList();
                model.Marriages= context.Marriage.Where(x => x.UserId == appSession.LoggedUser.Id).ToList();
                
            }
            return View("Index",model);
        }

        public ActionResult CancelAudience(int audienceId)
        {
            using (var context = new DbLicentaEntities())
            {
                context.Audience.FirstOrDefault(x => x.IdAudienta == audienceId).isCanceled=true;
                 context.SaveChanges();
            }
            return Index();
        }
        public ActionResult CancelMarriage(int marriageId)
        {
            using (var context = new DbLicentaEntities())
            {
                context.Marriage.FirstOrDefault(x => x.Id== marriageId).IsCanceled=true;
                 context.SaveChanges();
            }
            return Index();
        }


        [HttpGet]
        [Route("GetData")]
        public ActionResult GetData()
        {

            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            DbLicentaEntities context = new DbLicentaEntities();
            var data = context.Marriage.ToList();
            foreach (var line in context.Marriage.GroupBy(info => info.Date)
                .Select(group => new
                {
                    Metric = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Metric))
            {
                result.Add(new Tuple<string, string>(line.Metric, line.Count.ToString()));
            }

            return Json(JsonSerializer.Serialize(result),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetDataForPie")]
        public ActionResult GetDataForPie()
        {
          
            DbLicentaEntities context = new DbLicentaEntities();
            int primar = context.Audience.Where(x => x.SolicitareLa == "primar").Count();
            int secretar = context.Audience.Where(x => x.SolicitareLa == "secretar").Count();
            int contabil = context.Audience.Where(x => x.SolicitareLa == "contabil").Count();
            int avocat = context.Audience.Where(x => x.SolicitareLa == "avocat").Count();
            Ratio obj = new Ratio();
            obj.primar = primar;
            obj.contabil = contabil;
            obj.secretar = secretar;
            obj.avocat = avocat;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int primar { get; set; }
            public int secretar { get; set; }
            public int contabil { get; set; }
            public int avocat { get; set; }
        }


        public ActionResult GetStatistics()
        {
            return View("AdminStatistic");
        }
     
        public ActionResult GetAudiencesChart()
        {
            return View("_AudiencesChart");
        }
      
        public ActionResult GetMarriagesChart()
        {
            return View("_MarriagesChart");
        }

        public ActionResult BackToStatistics()
        {
            return View("AdminStatistic");
        }
            
    }
};