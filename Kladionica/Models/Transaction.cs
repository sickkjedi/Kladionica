using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Transaction
    {
        [Key]
        public ulong TransactionId { get; set; }
        public static DateTime Date { get; set; } = System.DateTime.Now;
        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }
        public bool Success { get; set; }

        public int UserID { get; set; } //FK
        public virtual User User { get; set; }

    }
}