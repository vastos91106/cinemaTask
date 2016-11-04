using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.Models.Abstract;

namespace Web.Models
{
    public class Session : BaseEntity
    {
        [Required()]
        public DateTime StartingDate;

        [Required]
        public int FilmID;

        public virtual  Film Film { get; set; }
    }
}