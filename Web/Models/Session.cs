using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web.Models.Abstract;

namespace Web.Models
{
    public class Session : BaseEntity
    {
        [Required(ErrorMessage = "Поле начало даты обязательно")]
        public DateTime StartingDate;

        [Required(ErrorMessage = "Поле фильм обязательно")]
        public int FilmID { get; set; }

        [ForeignKey(nameof(FilmID))]
        public virtual Film Film { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}