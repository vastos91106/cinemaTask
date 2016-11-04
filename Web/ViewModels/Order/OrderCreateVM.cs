using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels.Order
{
    public class OrderCreateVM
    {
        [Required]
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int SessionID { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 40, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Count;
    }
}