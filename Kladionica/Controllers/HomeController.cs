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

            return PartialView("_PairsList", selectedPairs);
        }

        public ActionResult Ticket()
        {

            return PartialView("_Ticket");
        }

        [HttpPost]
        public JsonResult InsertTicket(Models.Ticket newTicket)
        {
            //User auth placeholder
            Models.User currUser = db.Users.Find(1);
            if (newTicket != null)
            {
                if(currUser.Balance < newTicket.BetAmount)
                {
                    return Json(new { IsCreated = false, Message = "Ticket not created; Not enough funds." });
                }
                db.Users.Find(1).Balance = currUser.Balance - newTicket.BetAmount;
                db.Tickets.Add(newTicket);
                db.SaveChanges();
                return Json(new { IsCreated = true, Message = "Ticket successfuly created." });
            }

            return Json(new { IsCreated = false, Message = "Ticket not created; New ticket is null." });
        }


        public ActionResult TicketList()
        {

            return View(db.Tickets.ToList());
        }

        public ActionResult TransactionList()
        {

            return View(db.Transactions.ToList());
        }
    }
}