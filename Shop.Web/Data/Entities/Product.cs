using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        [MaxLength(100, ErrorMessage ="Field {0} must be {1} length")]
        [Required]
        public string Name { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        
        [Display(Name = "Last Purchase")]
        public Nullable<DateTime> LastPurchase { get; set; }
        
        [Display(Name = "Last Sale")]
        public Nullable<DateTime> LastSale { get; set; }
        
        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }
}
