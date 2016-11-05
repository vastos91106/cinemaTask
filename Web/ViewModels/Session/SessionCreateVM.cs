using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Session
{
    public class SessionCreateVM
    {
        [Required(ErrorMessage = "Поле начало даты обязательно для заполнения")]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "Поле фильм обязательно")]
        [Range(minimum: 1, maximum: Int32.MaxValue,ErrorMessage = "Фильм с таким именем не существует")]
        public int FilmID { get; set; }
    }
}