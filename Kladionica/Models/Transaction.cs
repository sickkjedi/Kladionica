using System;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }
        public bool Success { get; set; }

        public int UserId { get; set; } //FK
        public virtual User User { get; set; }

    }
}