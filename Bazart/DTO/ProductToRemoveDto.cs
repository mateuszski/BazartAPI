using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bazart.Models
{
    public class RemoveProductDto
    {
        public int ProductId { get; set; }
       public int UserId { get; set; }
    }
}