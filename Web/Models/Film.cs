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
        [Required(ErrorMessage = "Поле Название фильма обязательно")]
        public string Name { get; set; }
    }
}