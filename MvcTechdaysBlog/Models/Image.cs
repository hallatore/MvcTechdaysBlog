using System.ComponentModel.DataAnnotations;

namespace MvcTechdaysBlog.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string MIME { get; set; }

        public string Url { get; set; }
        public string Url2 { get; set; }
    }
}