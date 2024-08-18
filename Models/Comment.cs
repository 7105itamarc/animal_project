using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1907FirstWebAppAtempt.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string? CommentDetails{  get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
     
    }
}
