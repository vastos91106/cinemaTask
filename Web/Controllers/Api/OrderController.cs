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
            if (ModelState.IsValid)
            {
                if (!_context.Sessions.Any(x => x.ID == model.SessionID))
                {
                    ModelState.AddModelError(nameof(model.SessionID),"Сеанс с таким id не найден");
                    return BadRequest(ModelState);
                }
                else
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
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
