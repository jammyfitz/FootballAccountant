using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Payments()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Payments() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
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
