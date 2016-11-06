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
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Не выбран сеанс")]
        public int SessionID { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 40, ErrorMessage = "Количество заказанных билетов должно быть больше 0")]
        public int Count { get; set; }
    }
}