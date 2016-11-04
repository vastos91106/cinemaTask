using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.ViewModels.Session;

namespace Web.Controllers.Api
{
    public class SessionController : Controller
    {
        private EFContext _context = new EFContext();

        public ActionResult Create()
        {
            var model = new SessionCreateVM();
            return View(model);
        }

        public ActionResult Create(SessionCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var entityModel = new Session()
                {
                 FilmID   = model.FilmID,
                 StartingDate =  model.StartingDate
                };

                _context.Set<Session>().Add(entityModel);
                _context.SaveChanges();

                ViewBag["SuccessResult"] = "Сеанс упешно добавлен";
                return View();
            }
            else
            {
                return View(model);
            }
        }
    }
}