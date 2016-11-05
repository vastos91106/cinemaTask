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
        private EFContext _context;

        public SessionController(EFContext context)
        {
            _context = context;
        }

        public ActionResult Create()
        {
            var model = new SessionCreateVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreateVM model)
        {
            if (ModelState.IsValidField(nameof(model.FilmID)))
            {
                if (!_context.Films.Any(x => x.ID == model.FilmID))
                {
                    ModelState.AddModelError(nameof(model.FilmID), "Фильм с таким id не найден");
                }
            }
            if (ModelState.IsValidField(nameof(model.StartingDate)))
            {
                if (model.StartingDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError(nameof(model.StartingDate), "Дата меньше текущего дня");
                }
            }

            if (ModelState.IsValid)
            {
                var entityModel = new Session()
                {
                    FilmID = model.FilmID,
                    StartingDate = model.StartingDate
                };

                _context.Set<Session>().Add(entityModel);
                _context.SaveChanges();

                ViewBag.SuccessResult = "Сеанс упешно добавлен";
                return View(new SessionCreateVM());
            }
            else
            {
                return View(model);
            }
        }
    }
}