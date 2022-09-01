using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Bazart.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLng { get; set; }
    }
}
