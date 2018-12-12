using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchApp.Controllers;
using System.Web.Mvc;

namespace PeopleSearchApp.Tests.Controllers
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
        public void SearchName()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            JsonResult result = controller.SearchName("bar") as JsonResult;
            System.Diagnostics.Debug.WriteLine(result);
            // Assert
            Assert.IsNotNull(result.Data);
            
        }
    }
}
