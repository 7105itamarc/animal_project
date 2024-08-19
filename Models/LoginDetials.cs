
using _1907FirstWebAppAtempt.validations;
using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.Models
{
    public class LoginDetials
    {
        [Required]
        [Display(Name = "User Name: ")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "password: ")]
        public string? password { get; set; }
    }
}
