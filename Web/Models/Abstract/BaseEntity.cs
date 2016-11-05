using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Abstract
{
    public class BaseEntity
    {
        [Required]
        public int ID { get; set; }

        public DateTime DateCreate
        {
            get
            {
                return (this._dateCreate == default(DateTime))
                   ? this._dateCreate = DateTime.Now
                   : this._dateCreate;
            }
            set { this._dateCreate = value; }
        }

        private DateTime _dateCreate = default(DateTime);
    }
}