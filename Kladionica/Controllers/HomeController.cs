using System.Linq;
using System.Web.Mvc;
using Kladionica.DAL;

namespace Kladionica.Controllers
{
    public class HomeController : Controller
    {
        KladionicaInterface _inter = new KladionicaInterface();

        public ActionResult Index() 
        {
            return View(_inter.GetPairs());
        }

        public ActionResult SportSelect()
        {
            return PartialView("_SportSelect" , _inter.GetCategories());
        }

        public ActionResult PairsList(string sportName)
        {
            return PartialView("_PairsList", _inter.GetPairs(sportName));
        }

        public ActionResult Ticket()
        {
            return PartialView("_Ticket");
        }

        [HttpPost]
        public JsonResult InsertTicket(Models.Ticket newTicket)
        {
            return Json(_inter.CheckTicket(newTicket));
        }

        
    }
}