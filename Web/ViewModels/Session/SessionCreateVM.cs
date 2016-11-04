using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Session
{
    public class SessionCreateVM
    {
        [Required()]
        public DateTime StartingDate;

        [Required]
        public int FilmID;
    }
}