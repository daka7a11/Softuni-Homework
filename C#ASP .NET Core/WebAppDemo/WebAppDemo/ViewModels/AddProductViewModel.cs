using System;
using System.ComponentModel.DataAnnotations;
using WebAppDemo.Models.Enums;

namespace WebAppDemo.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3,ErrorMessage = "Name should be atleast 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01,10000 , ErrorMessage = "Price should be between 0.01 and 10 000")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1,1000, ErrorMessage = "Quantity should be between 1 and 1000.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Produced on")]
        public DateTime? ProducedOn { get; set; }

        public string Description { get; set; }
    }
}
