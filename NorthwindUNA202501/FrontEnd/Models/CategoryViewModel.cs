using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoryViewModel
    {
        [Display(Name ="Identificador")]
        public int CategoryId { get; set; }

        [Display(Name = "Nombre")]
        public string CategoryName { get; set; }
    }
}
