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
            return View(db.Pairs.ToList());
        }

        public ActionResult SportSelect()
        {
            return PartialView("_SportSelect" ,db.Categories.ToList());
        }

        public ActionResult PairsList(string sportName)
        {
            List<Models.Pair> selectedPairs = new List<Models.Pair>();
            selectedPairs = db.Pairs.ToList();

            //Filter pairs by category
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
            if (newTicket.TicketPairs != null)
            {
                //Add new transaction log with spent amount
                if(AddTransaction(currUser.UserId, -1.00m * newTicket.BetAmount))
                {
                    db.Tickets.Add(newTicket);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Listić uspješno uplaćen." });
                }

                return Json(new { success = false, message = "Listić nije moguće uplatiti, nedovoljan iznos na računu." });
            }

            return Json(new { success = false, message = "Greška - listić prazan." });
        }


        public ActionResult TicketList()
        {

            return View(db.Tickets.ToList());
        }

        public ActionResult TransactionList(string amount)
        {
            List<Models.Transaction> currUserTransactions = new List<Models.Transaction>();
            currUserTransactions = db.Transactions.Where(t => t.UserID.Equals(1)).ToList();

            //Current user balance -- placeholder for authentication
            ViewBag.Amount = db.Users.Find(1).Balance;

            //Controller confusing decimal point with "," sent sent by jQuery??? -- using string and parse decimal
            if (amount != null && amount != "0")
            {
                decimal amountd = decimal.Parse((string)amount);
                AddTransaction(1, amountd);
                return PartialView(currUserTransactions);
            }


            return View(currUserTransactions);
        }

        public ActionResult Contact()
        {
            return View();
        }

        private bool AddTransaction(int userID, decimal amount)
        {
            Models.Transaction transaction = new Models.Transaction();

            //If enough available funds create a new transaction
            if (db.Users.Find(userID).Balance + amount >= 0) { 

                db.Users.Find(userID).Balance += amount;
                transaction.Amount = amount;
                transaction.UserID = userID;
                transaction.Success = true;

                db.Transactions.Add(transaction);
                db.SaveChanges();
            }

            return transaction.Success;
        }
    }
}