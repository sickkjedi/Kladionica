using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Web;
using System.Web.Mvc;
using Kladionica.DAL;

namespace Kladionica.Controllers
{
    public class HomeController : Controller
    {
        private KladionicaContext db = new KladionicaContext();

        public ActionResult Index() 
        {
            return View(db.Categories.ToList());
        }

        public ActionResult PairsList(string sportName)
        {
            List<Models.Pair> selectedPairs = new List<Models.Pair>();
            selectedPairs = db.Pairs.ToList();

            if (!String.IsNullOrEmpty(sportName))
            {
                selectedPairs = db.Pairs.Where(p => p.Category.Name.Contains(sportName)).ToList();
            }

            return PartialView(selectedPairs);
        }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}