using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public CustomersController CreateCustomersController(CustomersViewModel TestData)
        {
            var repository = new FakeCustomersRepository(TestData);
            CustomersController customersController = new CustomersController(repository);
            var mocks = new ContextMocks(customersController);

            return customersController;
        }

        #endregion

        #region Tests

        #region Index

        [Test]
        public void IndexAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

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
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Grid();

            // Assert
            Assert.IsInstanceOf<CustomersViewModel>(result.ViewData.Model, "Index does not have an CustomersViewModel as a ViewModel");
        }

        [Test]
        public void GridAction_Should_Return_Total_of_4_Customers()
        {

            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Grid();
            
            // Assert
            Assert.AreEqual(4, ((CustomersViewModel)result.ViewData.Model).Customers.Count, "Incorrect amount of customers returned by Grid action");
        }

        [Test]
        public void GridAction_Should_Return_2nd_CustomerName_As_Customer2()
        {

            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

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
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Details view was not returned.");
        }

        [Test]
        public void DetailsAction_Returns_A_CustomerViewModel()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Details(1);

            // Assert
            Assert.IsInstanceOf<CustomerViewModel>(result.ViewData.Model, "Details does not have an CustomerViewModel as a ViewModel");
        }

        [Test]
        public void DetailsAction_Returns_CustomerName_As_Customer3_For_ID3()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Details(3);
            CustomerViewModel customersViewModel = (CustomerViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual("Customer3", customersViewModel.CustomerName, "Incorrect name returned for returned customer");
        }

        #endregion

        #region Edit

        [Test]
        public void EditAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Edit view was not returned.");
        }

        [Test]
        public void EditAction_Returns_A_CustomerViewModel()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Edit(1);

            // Assert
            Assert.IsInstanceOf<CustomerViewModel>(result.ViewData.Model, "Edit does not have an CustomerViewModel as a ViewModel");
        }

        [Test]
        public void EditAction_Returns_CustomerName_As_Customer2_For_ID2()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            ViewResult result = (ViewResult)controller.Edit(2);
            CustomerViewModel customersViewModel = (CustomerViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual("Customer2", customersViewModel.CustomerName, "Incorrect name returned for returned customer");
        }

        [Test]
        public void Edit_Customer_With_Values_Returns_RedirectToRouteResult()
        {
            // Arrange
            CustomersViewModel TestData = FakeCustomerData.CreateTestCustomers();

            var controller = CreateCustomersController(TestData);
            CustomerViewModel customerViewModel = TestData.Customers[0];

            // Act
            var result = controller.Edit(customerViewModel);
            
            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Save redirect route not returned.");
        }

        [Test]
        public void Edit_Customer_With_NoName_FailsValidation()
        {
            // Arrange
            CustomersViewModel TestData = FakeCustomerData.CreateTestCustomers();

            var controller = CreateCustomersController(TestData);
            CustomerViewModel customerViewModel = TestData.Customers[0];
            customerViewModel.CustomerName = "";

            var validationContext = new ValidationContext(customerViewModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(customerViewModel, validationContext, validationResults);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Act
            var result = controller.Edit(customerViewModel);

            // Assert
            Assert.IsNotNull(result, "View not rendered");
            Assert.IsInstanceOf<ViewResult>(result, "Invalid Save not rendering view.");

            ViewResult viewResult = (ViewResult)result;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName));
            Assert.IsNotNull(viewResult.ViewData.Model as CustomerViewModel, "Invalid view model");
            Assert.IsTrue(viewResult.ViewData.ModelState["CustomerName"].Errors.Count > 0);
        }

        [Test]
        public void Edit_Customer_With_Values_Returns_DetailsRoute()
        {
            // Arrange
            CustomersViewModel TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            CustomerViewModel customerViewModel = TestData.Customers[0];

            // Act
            var result = controller.Edit(customerViewModel);
            RedirectToRouteResult redirectToRoute = (RedirectToRouteResult) result;

            // Assert
            Assert.AreEqual(1, redirectToRoute.RouteValues["id"], "Incorrect redirect route ID returned");
            Assert.AreEqual("Details", redirectToRoute.RouteValues["action"], "Incorrect redirect route action returned");
            Assert.AreEqual("Customers", redirectToRoute.RouteValues["controller"], "Incorrect redirect route controller returned");
        }

        [Test]
        public void Edit_Customer_With_Values_SavesToStore()
        {
            // Arrange
            CustomersViewModel TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            CustomerViewModel customerViewModel = TestData.Customers[0];
            customerViewModel.CustomerName = "New Name";

            // Act
            var result = controller.Edit(customerViewModel);
            
            // Assert
            Assert.AreEqual("New Name", TestData.Customers[0].CustomerName, "Save method not updating values");
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteAction_Should_Return_RedirectToAction()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Delete redirect route was not returned.");
        }

        [Test]
        public void Delete_Customer_DeletesFromStore()
        {
            // Arrange
            CustomersViewModel TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            CustomerViewModel customerViewModel = TestData.Customers[0];

            // Act
            var result = controller.Delete(customerViewModel.CustomerID);

            // Assert
            Assert.AreEqual(3, TestData.Customers.Count, "Delete method not removing customer");
        }
        
        #endregion

        #endregion
    }
}
