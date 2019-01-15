using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kladionica.DAL;

namespace Kladionica.Controllers
{
    public class TicketsController : Controller
    {
        private KladionicaContext _db = new KladionicaContext();
        public ActionResult TicketList()
        {
            return View(_db.Tickets.ToList());
        }
    }
}