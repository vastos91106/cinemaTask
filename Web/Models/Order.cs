using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web.Models.Abstract;

namespace Web.Models
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessage = "Поле сеанс  обязательно")]
        public int SessionID { get; set; }

        [ForeignKey(nameof(SessionID))]
        public virtual Session Session { get; set; }

        [Required(ErrorMessage = "Поле количество билетов обязательно")]
        public int Count { get; set; }
    }
}