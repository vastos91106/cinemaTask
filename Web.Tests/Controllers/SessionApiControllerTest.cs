using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers.Api;
using Web.Models;
using Web.ViewModels.Session;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class SessionApiControllerTest
    {
        [TestMethod]
        public void GetSessions()
        {
            using (ShimsContext.Create())
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

                System.Data.Entity.Fakes.ShimDbFunctions.AddMinutesNullableOfDateTimeNullableOfInt32 = (time, i) =>
                {
                    if (time.HasValue)
                    {
                        time = time.Value.AddMinutes(i.Value);
                    }
                    return time.Value;
                };


                var mockSetSession = new Mock<DbSet<Session>>().SetupData(data);
                var context = new Mock<EFContext>();

                context.Setup(m => m.Sessions).Returns(mockSetSession.Object);
                var controller = new SessionApiController(context.Object) { Request = new HttpRequestMessage() };
                controller.Request.SetConfiguration(new HttpConfiguration());

                //valid date
                var contentResult = controller.GetSessions() as OkNegotiatedContentResult<List<SessionListVM>>;
                Assert.AreEqual(1, contentResult.Content.Count());

                //date is yesterday
                data = new List<Session>()
            {
                new Session()
                {
                    StartingDate = DateTime.Now.AddDays(-1),
                    Film = new Film()
                    {
                        Name = "test",
                        ID = 1
                    }
                }
            };
                mockSetSession = new Mock<DbSet<Session>>().SetupData(data);
                context.Setup(m => m.Sessions).Returns(mockSetSession.Object);
                controller = new SessionApiController(context.Object) { Request = new HttpRequestMessage() };
                controller.Request.SetConfiguration(new HttpConfiguration());

                contentResult = controller.GetSessions() as OkNegotiatedContentResult<List<SessionListVM>>;
                Assert.AreEqual(0, contentResult.Content.Count());


                //date -20minutes
                data = new List<Session>()
            {
                new Session()
                {
                    StartingDate = DateTime.Now.AddMinutes(-20),
                    Film = new Film()
                    {
                        Name = "test",
                        ID = 1
                    }
                }
            };
                mockSetSession = new Mock<DbSet<Session>>().SetupData(data);
                context.Setup(m => m.Sessions).Returns(mockSetSession.Object);
                controller = new SessionApiController(context.Object) { Request = new HttpRequestMessage() };
                controller.Request.SetConfiguration(new HttpConfiguration());

                contentResult = controller.GetSessions() as OkNegotiatedContentResult<List<SessionListVM>>;
                Assert.AreEqual(0, contentResult.Content.Count());

                //no data

                data = new List<Session>()
                {
                };

                mockSetSession = new Mock<DbSet<Session>>().SetupData(data);
                context.Setup(m => m.Sessions).Returns(mockSetSession.Object);
                controller = new SessionApiController(context.Object) { Request = new HttpRequestMessage() };
                controller.Request.SetConfiguration(new HttpConfiguration());

                contentResult = controller.GetSessions() as OkNegotiatedContentResult<List<SessionListVM>>;
                Assert.AreEqual(0, contentResult.Content.Count());
            }
        }
    }
}
