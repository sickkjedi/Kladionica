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

        public virtual ICollection<TicketPair> TicketPairs { get; set; } //navigacijski property
        //svaki par moze biti u vise listica

        public decimal GetTypeQuota(string Type)
        {
            switch (Type)
            {
                case "Type1": return Type1;
                case "Type2": return Type2;
                case "Typex": return Typex;
                default: return 0;
            }
        }

    }
}