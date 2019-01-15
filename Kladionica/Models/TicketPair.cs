using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kladionica.Models
{
    public class TicketPair
    {
        [Key, Column(Order = 0)]
        public int TicketId { get; set; } //FK
        [Key, Column(Order = 1)]
        public int PairId { get; set; } //FK

        public virtual Ticket Ticket { get; set; }
        public virtual Pair Pair { get; set; }

        public string Type { get; set; }
    }
}