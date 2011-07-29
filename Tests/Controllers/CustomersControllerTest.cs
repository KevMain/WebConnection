using System.Web.Mvc;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.Tests.Fakes;
using CCE.WebConnection.WebAppExternal.Controllers;
using NUnit.Framework;

namespace CCE.WebConnection.Tests.Controllers
{
    [TestFixture]
    public class CustomersControllerTest
    {
        #region Controller Mock

        CustomersController CreateCustomersController()
        {
            var testData = FakeCustomerData.CreateTestCustomers();
            var repository = new FakeCustomersRepository(testData);

            return new CustomersController(repository);
        }

        #endregion

        #region Tests

        #region Index

        [Test]
        public void IndexAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateCustomersController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Index view was not returned.");
        }

        #endregion

        #region Grid

        [Test]
        public void GridAction_Returns_TypedView_Of_List_CustomerViewModel()
        {
            // Arrange
            var controller = CreateCustomersController();

            // Act
            ViewResult result = (ViewResult)controller.Grid();

            // Assert
            Assert.IsInstanceOf<CustomersViewModel>(result.ViewData.Model, "Index does not have an CustomersViewModel as a ViewModel");
        }

        [Test]
        public void GridAction_Should_Return_Total_of_4_Customers()
        {

            // Arrange
            var controller = CreateCustomersController();

            // Act
            ViewResult result = (ViewResult)controller.Grid();
            
            // Assert
            Assert.AreEqual(4, ((CustomersViewModel)result.ViewData.Model).Customers.Count, "Incorrect amount of customers returned by Grid action");
        }

        [Test]
        public void GridAction_Should_Return_2nd_CustomerName_As_Customer2()
        {

            // Arrange
            var controller = CreateCustomersController();

            // Act
            ViewResult result = (ViewResult)controller.Grid();
            CustomersViewModel customersViewModel = (CustomersViewModel) result.ViewData.Model;

            // Assert
            Assert.AreEqual("Customer2", customersViewModel.Customers[1].CustomerName, "Incorrect name returned for 2nd customer");
        }

        #endregion

        #region Details

        [Test]
        public void DetailsAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateCustomersController();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Details view was not returned.");
        }

        [Test]
        public void DetailsAction_Returns_A_CustomerViewModel()
        {
            // Arrange
            var controller = CreateCustomersController();

            // Act
            ViewResult result = (ViewResult)controller.Details(1);

            // Assert
            Assert.IsInstanceOf<CustomerViewModel>(result.ViewData.Model, "Details does not have an CustomerViewModel as a ViewModel");
        }

        #endregion

        #endregion
    }
}
