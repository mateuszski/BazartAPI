using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazart.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
