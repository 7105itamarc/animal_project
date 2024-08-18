using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.Models
{
    public class MyLoginModel
    {
        [Required]
        public string? UserName { get; set; } 
        [Required]
        public string? Password { get; set; }
    }
}
