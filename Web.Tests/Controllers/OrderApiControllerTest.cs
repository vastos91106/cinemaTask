using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers.Api;
using Web.Models;
using Web.ViewModels.Order;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class OrderApiControllerTest
    {
        [TestMethod]
        public void PostOrder()
        {
            var data = new List<Session>()
            {
                new Session()
                {
                    ID = 1,
                    FilmID = 2
                }
            };

            var mockSet = new Mock<DbSet<Order>>();
            var mockSetSession = new Mock<DbSet<Session>>().SetupData(data);

            var context = new Mock<EFContext>();

            context.Setup(x => x.SaveChanges()).Returns(() => 1);
            context.Setup(m => m.Orders).Returns(mockSet.Object);
            context.Setup(m => m.Sessions).Returns(mockSetSession.Object);

            var controller = new OrderApiController(context.Object);
            var model = new OrderCreateVM();
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            controller.Validate(model);

            //model null
            var result = controller.PostOrder(model);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));

            // invalid sessionID
            controller.ModelState.Clear();
            model.SessionID = 10;
            controller.Validate(model);
            result = controller.PostOrder(model);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));

            // count = -10;
            controller.ModelState.Clear();
            model.Count = -10;
            controller.Validate(model);
            result = controller.PostOrder(model);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));

            //success
            controller.ModelState.Clear();
            model.SessionID = 1;
            model.Count = 1;
            controller.Validate(model);
            result = controller.PostOrder(model);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
