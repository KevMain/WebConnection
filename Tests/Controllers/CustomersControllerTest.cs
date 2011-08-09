using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CCE.WebConnection.BL.EntityMapper;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.Domain.Concrete;
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

        public CustomersController CreateCustomersController(IList<ICustomer> TestData)
        {
            var repository = new FakeCustomersRepository(TestData);
            CustomersController customersController = new CustomersController(repository);
            new ContextMocks(customersController);

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
            CustomersViewModel customersViewModel = (CustomersViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual("Customer2", customersViewModel.Customers[1].Name, "Incorrect name returned for 2nd customer");
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
            Assert.AreEqual("Customer3", customersViewModel.Name, "Incorrect name returned for returned customer");
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
            Assert.AreEqual("Customer2", customersViewModel.Name, "Incorrect name returned for returned customer");
        }

        [Test]
        public void Edit_Customer_With_Values_Returns_RedirectToRouteResult()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();

            var controller = CreateCustomersController(TestData);
            ICustomer customer = TestData[0];

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            // Act
            var result = controller.Edit(customerViewModel);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Save redirect route not returned.");
        }

        [Test]
        public void Edit_Customer_With_NoName_FailsValidation()
        {
            AutoMapperConfiguration.Configure(); 

            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();

            var controller = CreateCustomersController(TestData);
            ICustomer customer = TestData[0];
            customer.Name = "";

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            var validationContext = new ValidationContext(customerViewModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(customerViewModel, validationContext, validationResults);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Act
            var result = controller.Edit(customerViewModel.PkId);

            // Assert
            Assert.IsNotNull(result, "View not rendered");
            Assert.IsInstanceOf<ViewResult>(result, "Invalid Save not rendering view.");
            
            ViewResult viewResult = (ViewResult)result;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName));
            Assert.IsNotNull(viewResult.ViewData.Model as CustomerViewModel, "Invalid view model");
            Assert.IsTrue(viewResult.ViewData.ModelState["Name"].Errors.Count > 0);
        }

        [Test]
        public void Edit_Customer_With_Values_Returns_DetailsRoute()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            ICustomer customer = TestData[0];

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            // Act
            var result = controller.Edit(customerViewModel);
            RedirectToRouteResult redirectToRoute = (RedirectToRouteResult)result;

            // Assert
            Assert.AreEqual(1, redirectToRoute.RouteValues["id"], "Incorrect redirect route ID returned");
            Assert.AreEqual("Details", redirectToRoute.RouteValues["action"], "Incorrect redirect route action returned");
            Assert.AreEqual("Customers", redirectToRoute.RouteValues["controller"], "Incorrect redirect route controller returned");
        }

        [Test]
        public void Edit_Customer_With_Values_SavesToStore()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            ICustomer customer = TestData[0];
            customer.Name = "New Name";

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            // Act
            controller.Edit(customerViewModel);

            // Assert
            Assert.AreEqual("New Name", TestData[0].Name, "Save method not updating values");
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteAction_Should_Return_PartialViewResult()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<PartialViewResult>(result, "Delete partial view was not returned.");
        }

        [Test]
        public void Delete_Customer_DeletesFromStore()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);
            ICustomer customer = TestData[0];

            // Act
            controller.Delete(customer.PkId);

            // Assert
            Assert.AreEqual(3, TestData.Count, "Delete method not removing customer");
        }

        #endregion

        #region Create

        [Test]
        public void CreateAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateCustomersController(FakeCustomerData.CreateTestCustomers());

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Create view was not returned.");
        }

        [Test]
        public void Create_Customer_With_Values_Returns_RedirectToRouteResult()
        {
            AutoMapperConfiguration.Configure(); 

            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);

            var customer = new Customer {PkId = 49, Name = "Mr Smith"};

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            // Act
            var result = controller.Create(customerViewModel);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Create redirect route not returned.");
        }

        [Test]
        public void Create_Customer_With_NoName_FailsValidation()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);

            var customer = new Customer { PkId = 49, Name = "" };

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            var validationContext = new ValidationContext(customerViewModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(customerViewModel, validationContext, validationResults);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Act
            var result = controller.Create(customerViewModel);
            
            // Assert
            Assert.IsNotNull(result, "View not rendered");
            Assert.IsInstanceOf<ViewResult>(result, "Invalid Save not rendering view.");

            ViewResult viewResult = (ViewResult)result;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName));
            Assert.IsTrue(viewResult.ViewData.ModelState["Name"].Errors.Count > 0);
        }

        [Test]
        public void Create_Customer_With_Values_Returns_DetailsRoute()
        {
            AutoMapperConfiguration.Configure(); 

            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);

            var customer = new Customer { PkId = 49, Name = "Mr Smith" };

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            // Act
            var result = controller.Create(customerViewModel);
            RedirectToRouteResult redirectToRoute = (RedirectToRouteResult)result;

            // Assert
            Assert.AreEqual("Grid", redirectToRoute.RouteValues["action"], "Incorrect redirect route action returned");
            Assert.AreEqual("Customers", redirectToRoute.RouteValues["controller"], "Incorrect redirect route controller returned");
        }

        [Test]
        public void Create_Customer_With_Values_SavesToStore()
        {
            // Arrange
            IList<ICustomer> TestData = FakeCustomerData.CreateTestCustomers();
            var controller = CreateCustomersController(TestData);

            var customer = new Customer { PkId = 49, Name = "Mr Smith" };

            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            AutoMapperConfiguration.Configure();

            // Act
            controller.Create(customerViewModel);

            // Assert
            Assert.AreEqual(5, TestData.Count, "Create method not adding customer");
            Assert.AreEqual("Mr Smith", TestData[4].Name, "Create method not adding values correctly");
        }

        #endregion

        #endregion
    }
}
