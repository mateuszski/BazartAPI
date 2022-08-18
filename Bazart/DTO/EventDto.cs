using System.ComponentModel.DataAnnotations;
using Bazart.Models;

namespace Bazart.API.DTO
{
    public class EventDto
    {
        //[Display(Name = "Event")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public User Owner { get; set; }
    }
}
