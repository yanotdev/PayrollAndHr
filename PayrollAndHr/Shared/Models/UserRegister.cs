using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAndHr.Shared.Models
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Username { get; set; }
        public long UserID { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string UserRole { get; set; }
        public string Department { get; set; }
        public string OtherID { get; set; }
        public string ImageUrl { get; set; }
    }
}
