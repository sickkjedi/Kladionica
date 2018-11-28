using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kladionica.Models
{
    public class TicketPair
    {
        public enum Type_of_bet
        {
            Type1 = '1',
            Type2 = '2',
            Typex = 'x'
        }
        [Key, Column(Order = 0)]
        public int TicketID { get; set; } //FK
        [Key, Column(Order = 1)]
        public int PairID { get; set; } //FK

        public virtual Ticket Ticket { get; set; }
        public virtual Pair Pair { get; set; }
        [Required]
        public Type_of_bet Type { get; set; }
    }
}