using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels.Film;

namespace Web.ViewModels.Session
{
    public class SessionListVM
    {
        public int ID { get; set; }
        public FilmVM Film { get; set; }

        public DateTime StartingDate { get; set; }
    }
}