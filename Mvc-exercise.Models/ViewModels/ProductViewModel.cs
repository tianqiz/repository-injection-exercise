using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc_exercise.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}