using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Select Bet Amount")]
        [Display(Name = "Bet Amount")]
        public decimal BetAmount { get; set; }
        public DateTime Date { get; set; } = System.DateTime.Now;
        public bool BonusQuota5 { get; set; } = false;
        public bool BonusQuota10 { get; set; } = false;

        public int UserID { get; set; } //FK
        public virtual User User { get; set; }

        public virtual ICollection<TicketPair> TicketPairs { get; set; } //navigacijski property
        //svaki ticket sadrzi vise parova

        public decimal GetTotalQuota()
        {
            decimal sum = 0;
            foreach(TicketPair ticketPair in TicketPairs)
            {
                string Type = ticketPair.Type;
                sum += ticketPair.Pair.GetTypeQuota(Type);
            }

            return sum;
        }
    }
}