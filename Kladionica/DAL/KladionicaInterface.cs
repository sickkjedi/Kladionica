using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace Kladionica.DAL
{
    public class KladionicaInterface
    {
        private KladionicaContext _db = new KladionicaContext();

        public List<Models.Pair> GetPairs(string sportName = null)
        {
            var selectedPairs = _db.Pairs.ToList();

            //Filter pairs by category
            if (!string.IsNullOrEmpty(sportName))
            {
                selectedPairs = _db.Pairs.Where(p => p.Category.Name.Contains(sportName)).ToList();
            }

            return selectedPairs;
        }

        public List<Models.Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public object CheckTicket(Models.Ticket newTicket)
        {
            //User auth placeholder
            var currUser = _db.Users.Find(1);
            if (newTicket.TicketPairs != null)
            {
                if (newTicket.BetAmount <= 0) return (new { success = false, message = $"Neispravan ulog: {newTicket.BetAmount}KN - Unesite pozitivan iznos." });
                //Add new transaction log with spent amount
                if (currUser != null && AddTransaction(currUser.UserId, -1.00m * newTicket.BetAmount))
                {
                    _db.Tickets.Add(newTicket);
                    _db.SaveChanges();

                    return (new { success = true, message = "Listić uspješno uplaćen." });
                }

                return (new { success = false, message = "Listić nije moguće uplatiti, nedovoljan iznos na računu." });
            }

            return (new { success = false, message = "Greška - listić prazan." });
        }

        public List<Models.Transaction> GeTransactions(int userId, string amount = null)
        {
            var currUserTransactions = _db.Transactions.Where(t => t.UserId.Equals(userId)).ToList();

            //Controller confusing decimal point with "," sent sent by jQuery??? -- using string and parse decimal
            if (amount != null)
            {
                var amountd = decimal.Parse(amount);
                AddTransaction(userId, amountd);
                return currUserTransactions;
            }

            return currUserTransactions;
        }

        public decimal GetBalance(int userId)
        {
            if (_db.Users != null) return _db.Users.Find(userId).Balance;

            return 0m;
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