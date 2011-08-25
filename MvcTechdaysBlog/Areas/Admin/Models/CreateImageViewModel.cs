using System.ComponentModel.DataAnnotations;
using System.Web;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Areas.Admin.Models
{
    public class CreateImageViewModel : Image
    {
        [Required]
        public HttpPostedFileBase HttpPostedFileBase { get; set; }
    }
}