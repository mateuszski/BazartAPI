using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazart.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}