using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcTechdaysBlog.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Remote("UniqueUrlCheck", "Article")]
        public string Url { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}