using System.Linq;
using System.Web.Mvc;
using Kladionica.DAL;

namespace Kladionica.Controllers
{
    public class HomeController : Controller
    {
        private KladionicaContext _db = new KladionicaContext();

        public ActionResult Index() 
        {
            return View(_db.Pairs.ToList());
        }

        public ActionResult SportSelect()
        {
            return PartialView("_SportSelect" ,_db.Categories.ToList());
        }

        public ActionResult PairsList(string sportName)
        {
            var selectedPairs = _db.Pairs.ToList();

            //Filter pairs by category
            if (!string.IsNullOrEmpty(sportName))
            {
                selectedPairs = _db.Pairs.Where(p => p.Category.Name.Contains(sportName)).ToList();
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
            var currUser = _db.Users.Find(1);
            if (newTicket.TicketPairs != null)
            {
                //Add new transaction log with spent amount
                if(currUser != null && AddTransaction(currUser.UserId, -1.00m * newTicket.BetAmount))
                {
                    _db.Tickets.Add(newTicket);
                    _db.SaveChanges();

                    return Json(new { success = true, message = "Listić uspješno uplaćen." });
                }

                return Json(new { success = false, message = "Listić nije moguće uplatiti, nedovoljan iznos na računu." });
            }

            return Json(new { success = false, message = "Greška - listić prazan." });
        }


        public ActionResult TicketList()
        {

            return View(_db.Tickets.ToList());
        }

        public ActionResult TransactionList(string amount)
        {
            var currUserTransactions = _db.Transactions.Where(t => t.UserId.Equals(1)).ToList();

            //Current user balance -- placeholder for authentication
            if (_db.Users != null) ViewBag.Amount = _db.Users.Find(1).Balance;

            //Controller confusing decimal point with "," sent sent by jQuery??? -- using string and parse decimal
            if (amount != null && amount != "0")
            {
                var amountd = decimal.Parse((string)amount);
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
            var transaction = new Models.Transaction();

            //If enough available funds create a new transaction
            if (_db != null && _db.Users.Find(userID).Balance + amount >= 0)
            {
                _db.Users.Find(userID).Balance += amount;
                transaction.Amount = amount;
                transaction.UserId = userID;
                transaction.Success = true;

                _db.Transactions.Add(transaction);
                _db.SaveChanges();

                return transaction.Success;
            }

            return transaction.Success;
        }
    }
}