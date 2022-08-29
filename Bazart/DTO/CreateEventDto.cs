using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Bazart.Models;

namespace Bazart.API.DTO
{
    public class CreateEventDto
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
        public string ImageUrl { get; set; }
        public int OwnerId { get; set; }
    }
}
