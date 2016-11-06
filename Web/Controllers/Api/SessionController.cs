using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;
using Web.ViewModels.Film;
using Web.ViewModels.Session;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/sessions")]
    public class SessionApiController : ApiController
    {
        private EFContext _context;

        public SessionApiController(EFContext context)
        {
            _context = context;
        }

        [Route()]
        public IHttpActionResult GetSessions()
        {
            var model = _context.Sessions
                .Where(x => x.StartingDate >= DbFunctions.AddMinutes(DateTime.Now, -20))
                .Select(session => new SessionListVM()
                {
                    StartingDate = session.StartingDate,
                    ID = session.ID,
                    Film = new FilmVM()
                    {
                        ID = session.Film.ID,
                        Name = session.Film.Name
                    }
                }).ToList();

            return Ok(model);
        }
    }
}
