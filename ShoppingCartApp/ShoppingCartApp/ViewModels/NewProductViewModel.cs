using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApp.ViewModels
{
    public class NewProductViewModel
    {
        public int ProductId { get; set; }
        public string CurrentCategory { get; set; }

        [Required(ErrorMessage = "Please enter name of product")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter category of product")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        
        [Required(ErrorMessage = "Please enter short description of product")]
        [StringLength(100)]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter long description of product")]
        [StringLength(500)]
        [Display(Name = "Long description")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Please enter price of product")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Please choose file to upload")]
        //[DataType(DataType.Upload)]
        //[Display(Name = "Image of product")]
        //public string File { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime NewProductAdded { get; set; }
    }
}
