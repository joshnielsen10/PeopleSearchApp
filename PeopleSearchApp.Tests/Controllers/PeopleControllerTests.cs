using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchApp.Controllers;
using PeopleSearchApp.Models;
using PeopleSearchApp.Models.DAL;
using System.Net;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace PeopleSearchApp.Tests.Controllers
{
    [TestClass()]
    public class PeopleControllerTests
    {
        [TestMethod()]
        public void GetPersonTest()
        {
            // Arrange
            PeopleController controller = new PeopleController();

            // Act
            IHttpActionResult actionResult = controller.GetPerson(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Person>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.PersonID);
        }

        [TestMethod()]
        public void GetPersonTest1()
        {
            // Arrange
            PeopleController controller = new PeopleController();

            // Act
            IHttpActionResult actionResult = controller.GetPerson(7);

            //Assert
            Assert.IsNull(actionResult as OkNegotiatedContentResult<Person>);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void PutPersonTest()
        {
            // Arrange
            PeopleController controller = new PeopleController();
            PersonContext context = new PersonContext();
            Person p1 = context.Person.Where(e => e.PersonID == 3).First();
            p1.FirstName = "Daffy";

            // Act
            IHttpActionResult actionResult = controller.PutPerson(3, p1);
            var contentResult = actionResult as NegotiatedContentResult<Person>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.PersonID);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
        }

        [TestMethod()]
        public void PostPersonTest()
        {
            // Arrange
            PeopleController controller = new PeopleController();
            Person p6 = new Person()
            {
                PersonID = 6,
                FirstName = "Delete",
                LastName = "Test",
                StreetAddress = "4321 Gone Circle",
                City = "Salt Lake",
                State = "Utah",
                Zip = "84129",
                Age = 10,
                Interests = "coding, testing, health catalyst",
                PhotoPath = ""
            };

            // Act
            IHttpActionResult actionResult = controller.PostPerson(p6);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Person>;

            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi",createdResult.RouteName);
            Assert.AreEqual(6, createdResult.RouteValues["id"]);
        }

        [TestMethod()]
        public void DeletePersonTest()
        {
            // Arrange
            PeopleController controller = new PeopleController();
            Person p6 = new Person()
            {
                PersonID = 6,
                FirstName = "Delete",
                LastName = "Test",
                StreetAddress = "4321 Gone Circle",
                City = "Salt Lake",
                State = "Utah",
                Zip = "84129",
                Age = 10,
                Interests = "coding, testing, health catalyst",
                PhotoPath = ""
            };

            // Act
            IHttpActionResult postAction = controller.PostPerson(p6);
            IHttpActionResult actionResult = controller.DeletePerson(6);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Person>));
        }
    }
}