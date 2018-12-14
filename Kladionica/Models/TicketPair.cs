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
        [Key, Column(Order = 0)]
        public int TicketID { get; set; } //FK
        [Key, Column(Order = 1)]
        public int PairID { get; set; } //FK
        [Required]
        public char Type { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Pair Pair { get; set; }
    }
}