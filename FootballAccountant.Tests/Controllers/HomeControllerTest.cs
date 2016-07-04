using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballAccountant;
using FootballAccountant.Controllers;

namespace FootballAccountant.Tests.Controllers
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
        public void Move()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Move() as ViewResult;

            // Assert
            Assert.AreEqual("Move MP3s.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Charges()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Charges() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
