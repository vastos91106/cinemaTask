using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels.Film;

namespace Web.ViewModels.Session
{
    public class SessionListVM
    {
        public int ID;
        public FilmVM Film { get; set; }
    }
}