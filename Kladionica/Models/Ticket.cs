using System;
using System.Collections.Generic;
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
        public DateTime Date { get; } = System.DateTime.Now;
        public bool BonusQuota5 { get; set; } = false;
        public bool BonusQuota10 { get; set; } = false;

        public int UserId { get; set; } //FK
        public User User { get; set; }

        public ICollection<TicketPair> TicketPairs { get; set; } //Navigation property

        public decimal GetTotalQuota()
        {
            decimal mul = 1;
            foreach(var ticketPair in TicketPairs)
            {
                var type = ticketPair.Type;
                mul *= ticketPair.Pair.GetTypeQuota(type);
            }

            return mul;
        }
    }
}