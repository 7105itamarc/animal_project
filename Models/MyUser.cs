
using _1907FirstWebAppAtempt.validations;
using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.Models
{
<<<<<<<< HEAD:‏‏‏‏‏‏‏‏1907FirstWebAppAtempt - 5/1907FirstWebAppAtempt/Models/LoginDetials.cs
    public class LoginDetials
========
    public class MyUser
>>>>>>>> 26281e4ca54093c2eef448ab8311b83ba2c3019b:‏‏‏‏‏‏‏‏1907FirstWebAppAtempt - 5/1907FirstWebAppAtempt/Models/MyUser.cs
    {
        [Required]
        [Display(Name = "User Name: ")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "password: ")]
        public string? password { get; set; }
    }
}
