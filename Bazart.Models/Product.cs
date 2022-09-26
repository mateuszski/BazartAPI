using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //[Required]
        public int Quantity { get; set; }

        [Required]
        public bool isForSale { get; set; }

        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Category> Categories { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}