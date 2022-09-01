using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazart.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bazart.API.DTO
{
    public class UpdateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLng { get; set; }
    }
}
