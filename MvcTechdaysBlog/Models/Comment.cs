using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcTechdaysBlog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [Remote("BadWords", "Validation")]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}