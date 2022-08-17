using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bazart.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        [ForeignKey("User.Id")]
        public User Owner { get; set; }
        //[AllowNull]
        //[ForeignKey("Owner.Id")]
        //public virtual List<User> ParticipantList { get; set; }
        public string ImageUrl { get; set; }

    }
}
