using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class ProductsModel
    {
        [Required(ErrorMessage = "Pleade enter Product Id")]
        [Display(Name ="Product Id")]
      
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Product Name")]
       
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}