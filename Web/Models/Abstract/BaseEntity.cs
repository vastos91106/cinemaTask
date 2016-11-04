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

        private DateTime _DateCreate { get; set; }

        public DateTime DateCreate
        {
            get { return _DateCreate; }
          protected  set
            {
                _DateCreate = DateTime.Now;
            }
        }
    }
}