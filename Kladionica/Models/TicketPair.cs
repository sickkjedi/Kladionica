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

        public Ticket Ticket { get; set; }
        public Pair Pair { get; set; }

        public string Type { get; set; }
    }
}