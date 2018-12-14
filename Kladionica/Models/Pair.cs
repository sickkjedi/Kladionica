using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Pair
    {
        [Key]
        public int PairId { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Pair1 { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Pair2 { get; set; }
        public string FullPair
        {
            get
            {
                return Pair1 + " - " + Pair2;
            }
        }
        [Required]
        public decimal Type1 { get; set; }
        [Required]
        public decimal Type2 { get; set; }
        [Required]
        public decimal Typex { get; set; }
        public DateTime StartDate { get; set; }
        public char Result { get; set; } = 'N';

        public int CategoryID { get; set; } //FK
        public virtual Category Category { get; set; }

        public virtual ICollection<TicketPair> TicketPairs { get; set; } //navigation property

        public decimal GetTypeQuota(char Type)
        {
            switch (Type)
            {
                case '1': return Type1;
                case '2': return Type2;
                case 'x': return Typex;
                default: return 0;
            }
        }

    }
}