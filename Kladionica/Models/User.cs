using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email address.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; } = 0;


    }
}