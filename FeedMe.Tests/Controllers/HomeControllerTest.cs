using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe;
using FeedMe.Controllers;

namespace FeedMe.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Search() as ViewResult;

            // Assert
            Assert.AreEqual("Search the Edamam API for recipes.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Edit() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
