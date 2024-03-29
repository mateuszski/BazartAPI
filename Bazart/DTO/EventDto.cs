﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Bazart.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bazart.API.DTO
{
    public class EventDto
    {
        //[Display(Name = "Event")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        [AllowNull]
        public string ImageUrl { get; set; }
        public int OwnerId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MapLng { get; set; }
        //public User Owner { get; set; }
        //[AllowNull]
        //public List<User> Users { get; set; }
    }
}
