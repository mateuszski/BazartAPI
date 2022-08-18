using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazart.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("User.Id")]
        public int UserId { get; set; }
        public User User { get; set; }
        //public int ProductId { get; set; }
        //[ForeignKey("ProductId")]
        public List<Product> Products { get; set; }
    }
}
