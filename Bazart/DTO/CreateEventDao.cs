using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Bazart.Models;

namespace Bazart.API.DTO
{
    public class CreateEventDao
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Adress { get; set; }
        //[ForeignKey("User.Id")]
        [AllowNull]
        //public User Owner { get; set; }
        //[AllowNull]
        //[ForeignKey("Owner.Id")]
        //public virtual List<User> Users { get; set; }
        public string ImageUrl { get; set; }
    }
}
