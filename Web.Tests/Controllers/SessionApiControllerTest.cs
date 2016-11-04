using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers.Api;
using Web.Models;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class SessionApiControllerTest
    {
        [TestMethod]
        public void GetSessions()
        {
            var data = new List<Session>()
            {
                new Session()
                {
                    StartingDate = DateTime.Now,
                    Film = new Film()
                    {
                        Name = "test",
                        ID = 1
                    }
                }
            };

            var mockSetSession = new Mock<DbSet<Session>>().SetupData(data);
            var context = new Mock<EFContext>();

            context.Setup(m => m.Sessions).Returns(mockSetSession.Object);
            var controller = new SessionApiController(context.Object) {Request = new HttpRequestMessage()};
            controller.Request.SetConfiguration(new HttpConfiguration());

            controller.GetSessions();
        }
    }
}
