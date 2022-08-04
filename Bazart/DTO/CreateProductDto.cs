using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bazart.Models
{
    public class  CreateProductDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        //[Required]
        public decimal? Price { get; set; }
        //[Required]
        public int Quantity { get; set; }
        [Required]
        public bool isForSale { get; set; }
        [Required]
        [Display(Name = "Art Picture")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
