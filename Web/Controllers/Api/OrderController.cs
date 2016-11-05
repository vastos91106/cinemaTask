using System;
using System.Linq;
using System.Web.Http;
using Web.Models;
using Web.ViewModels.Order;

namespace Web.Controllers.Api
{
    public class OrderApiController : ApiController
    {
        private EFContext _context;

        public OrderApiController(EFContext context)
        {
            _context = context;
        }

        public IHttpActionResult PostOrder(OrderCreateVM model)
        {

            if (ModelState.IsValidField(nameof(model.SessionID)))
            {
                var session = _context.Sessions.Find(model.SessionID);
                if (session == null)
                {
                    ModelState.AddModelError(nameof(model.SessionID), "Сеанс с таким id не найден");
                }
                else
                {
                    if (session.StartingDate < DateTime.Now.AddMinutes(-30.0))
                    {
                        ModelState.AddModelError(nameof(model.SessionID), "Запись на идущий сеанс запрещена");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var entityModel = new Order()
                {
                    SessionID = model.SessionID,
                    Count = model.Count
                };

                _context.Set<Order>().Add(entityModel);
                _context.SaveChanges();

                return Ok();

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
