using _1907FirstWebAppAtempt.validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1907FirstWebAppAtempt.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required]
        public string? Name { get; set; }
        [IsPossitiveNumber]
        public int Age { get; set; }
        public string? PictureName { get; set; }
        [MaxLength(40)]
        public string? Description { get; set; }
        
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
