using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.Models.Abstract;

namespace Web.Models
{
    public class Film : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}