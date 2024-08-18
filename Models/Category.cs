using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
