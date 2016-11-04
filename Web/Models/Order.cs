using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.Models.Abstract;

namespace Web.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public int SessionID;

        public virtual Session Session { get; set; }

        [Required]
        public int Count { get; set; }
    }
}