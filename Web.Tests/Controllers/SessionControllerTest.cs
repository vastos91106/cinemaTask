using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers.Api;
using Web.Models;
using Web.ViewModels.Session;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class SessionControllerTest
    {
        [TestMethod]
        public void Create()
        {
            var data = new SessionCreateVM();

            var mockSetFilm = new Mock<DbSet<Film>>().SetupData(new List<Film>()
            {
                new Film()
                {
                    ID = 1,
                    Name = "test"
                }
            });

            var mockSet = new Mock<DbSet<Session>>();
            var context = new Mock<EFContext>();

            context.Setup(x => x.SaveChanges()).Returns(() => 1);
            context.Setup(m => m.Sessions).Returns(mockSet.Object);
            context.Setup(m => m.Films).Returns(mockSetFilm.Object);
            var controller = new SessionController(context.Object);
            controller.ValidateRequest = true;

            //empty model
            var result = controller.Create(data) as ViewResult;
            Assert.AreEqual(null, result.ViewBag.SuccessResult);

            //invalid film & starting date yesterday
            controller.ModelState.Clear();
            data.FilmID = 20;
            data.StartingDate = DateTime.Now.AddDays(-1);

            result = controller.Create(data) as ViewResult;
            Assert.AreEqual(null, result.ViewBag.SuccessResult);

            //success
            controller.ModelState.Clear();
            data.FilmID = 1;
            data.StartingDate = DateTime.Now;
            result = controller.Create(data) as ViewResult;

            Assert.AreNotEqual(null, result.ViewBag.SuccessResult);
        }
    }
}
