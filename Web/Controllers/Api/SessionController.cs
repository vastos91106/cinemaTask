using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;
using Web.ViewModels.Film;
using Web.ViewModels.Session;

namespace Web.Controllers.Api
{
    public class SessionApiController : ApiController
    {
        private EFContext _context;

        public SessionApiController(EFContext context)
        {
            _context = context;
        }

        public IHttpActionResult GetSessions()
        {
            var t = _context.Sessions.ToList();
            var model = _context.Sessions
                .Where(x => DbFunctions.TruncateTime(x.StartingDate) >= DbFunctions.TruncateTime(DateTime.Now))
                .Select(session => new SessionListVM()
                {
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
