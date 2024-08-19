using _1907FirstWebAppAtempt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.ViewModel
{
    public class AnimalViewModel : Animal
    {
        public IFormFile? photo {  get; set; }
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem>? CategoryOptions { get; set; }

    }
}
