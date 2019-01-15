using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kladionica.DAL;

namespace Kladionica.Controllers
{
    public class TransactionsController : Controller
    {
        KladionicaInterface _inter = new KladionicaInterface();
        public ActionResult TransactionList(string amount)
        {
            //Current user balance -- placeholder for authentication
            ViewBag.Amount = _inter.GetBalance(1);

            if (amount != null && amount != "0")
            {
                return PartialView(_inter.GeTransactions(1, amount));
            }

            return View(_inter.GeTransactions(1));
        }

    }
}