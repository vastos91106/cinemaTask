using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NinjaNye.SearchExtensions;
using Web.Models;
using Web.ViewModels.Film;
using WebApi.OutputCache.V2;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/films")]
    public class FilmController : ApiController
    {
        private EFContext _context;

        public FilmController(EFContext context)
        {
            _context = context;
        }

        [Route("{searchTerm}")]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public IHttpActionResult GetFilms(string searchTerm)
        {
            var model = _context.Films.Search(x => x.Name).ContainingAll(searchTerm)
                .Select(film => new FilmVM()
                {
                    Name = film.Name,
                    ID = film.ID
                }).ToList();

            return Ok(model);
        }
    }
}
