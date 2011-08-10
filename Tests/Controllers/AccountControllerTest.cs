using System;
using System.Web.Mvc;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.Tests.Fakes;
using CCE.WebConnection.WebAppExternal.Controllers;
using NUnit.Framework;

namespace CCE.WebConnection.Tests.Controllers
{
    public class AccountControllerTest
    {
        #region Controller Mock
        
        public AccountController CreateAccountController()
        {
            //-- Setup fake mock services
            var formsAuthenticationService = new FakeFormAuthenticationService();
            var membershipService = new FakeMembershipService();
            
            //-- Set up controller
            AccountController accountController = new AccountController(formsAuthenticationService, membershipService);
            
            //-- Set Mocks
            new ContextMocks(accountController);

            return accountController;
        }

        #endregion

        #region Tests

        [Test]
        public void LoginAction_Should_Return_View()
        {
            // Arrange
            var controller = CreateAccountController();

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "Index view was not returned.");
        }

        [Test]
        public void LoginAction_ReturnsRedirectToRouteResultIfLogonSuccessAndNoReturnUrlGiven()
        {
            // Arrange
            var controller = CreateAccountController();
            var user = new LoginViewModel {UserName = "username", Password = "password"};

            // Act
            var result = controller.Login(user, String.Empty);
            var redirectresult = (RedirectToRouteResult)result;

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Redirect to route not returned.");
            Assert.AreEqual("Customers", redirectresult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectresult.RouteValues["action"]);
        }

        [Test]
        public void LoginAction_ReturnsRedirectToRouteResultIfLogonSuccessAndReturnUrlGiven()
        {
            // Arrange
            var controller = CreateAccountController();
            var user = new LoginViewModel { UserName = "username", Password = "password" };

            // Act
            var result = controller.Login(user, "someurl");
            var redirectResult = (RedirectResult)result;

            // Assert
            Assert.IsInstanceOf<RedirectResult>(result, "Redirect not returned.");
            Assert.AreEqual("someurl", redirectResult.Url, "Correct redirect URL not returned");
        }

        [Test]
        public void LoginAction_ReturnsViewIfInvalidModelState()
        {
            // Arrange
            var controller = CreateAccountController();
            var user = new LoginViewModel {UserName = "username", Password = "password"};
            controller.ModelState.AddModelError("*", "Invalid model state.");

            // Act
            var result = controller.Login(user, "someurl");
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");
            Assert.AreSame(user, viewResult.ViewData.Model, "User and Model are not the same");
        }

        [Test]
        public void LoginAction_ReturnsViewIfLogonFails()
        {
            // Arrange
            var controller = CreateAccountController();
            var user = new LoginViewModel { UserName = "wrong", Password = "wrong" };
            
            // Act
            var result = controller.Login(user, "someurl");
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");
            Assert.AreSame(user, viewResult.ViewData.Model, "User and Model are not the same");
            Assert.AreEqual(false, viewResult.ViewData.ModelState.IsValid);
        }

        [Test]
        public void ChangePasswordAction_ReturnsView()
        {
            // Arrange
            var controller = CreateAccountController();
            
            // Act
            var result = controller.ChangePassword();
            
            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");
        }

        [Test]
        public void ChangePasswordAction_ReturnsViewIfInvalidModelState()
        {
            // Arrange
            var controller = CreateAccountController();
            var changePasswordView = new ChangePasswordViewModel { UserName = "TestUser", OldPassword = "password", NewPassword = "pa33word" };
            controller.ModelState.AddModelError("*", "Invalid model state.");

            // Act
            var result = controller.ChangePassword(changePasswordView);
            
            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");

            var viewResult = (ViewResult)result;
            Assert.AreSame(changePasswordView, viewResult.ViewData.Model, "User and Model are not the same");
        }

        [Test]
        public void ChangePasswordAction_ReturnsViewIfFails()
        {
            // Arrange
            var controller = CreateAccountController();
            var changePasswordView = new ChangePasswordViewModel { UserName = "wrong", OldPassword = "wrong", NewPassword = "pa33word" };
            
            // Act
            var result = controller.ChangePassword(changePasswordView);
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");
            Assert.AreSame(changePasswordView, viewResult.ViewData.Model, "User and Model are not the same");
            Assert.AreEqual(false, viewResult.ViewData.ModelState.IsValid);
        }

        [Test]
        public void ChangePasswordAction_WithValidValuesReturnsRedirectToRoute()
        {
            // Arrange
            var controller = CreateAccountController();
            var changePasswordView = new ChangePasswordViewModel { UserName = "TestUser", OldPassword = "password", NewPassword = "pa33word" };

            // Act
            var result = controller.ChangePassword(changePasswordView);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "RedirectToRouteResult not returned.");
        }

        [Test]
        public void ChangePasswordAction_WithValidValuesUpdatesPassword()
        {
            // Arrange
            var controller = CreateAccountController();

            var user = new LoginViewModel { UserName = "TestUser", Password = "password" };
            var changePasswordView = new ChangePasswordViewModel { UserName = "TestUser", OldPassword = "password", NewPassword = "pa33word" };

            // Act
            var result = controller.ChangePassword(changePasswordView);
            
            // Assert
            //Assert.IsInstanceOf<RedirectToRouteResult>(result, "Redirect to route not returned.");
            //Assert.AreEqual("Customers", redirectresult.RouteValues["controller"]);
            //Assert.AreEqual("Index", redirectresult.RouteValues["action"]);
        }


        [Test]
        public void ChangePasswordSuccessAction_ReturnsView()
        {
            // Arrange
            var controller = CreateAccountController();

            // Act
            var result = controller.ChangePasswordSuccess();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result, "ViewResult not returned.");
        }

        [Test]
        public void LogOffAction_ReturnsRedirectToAction()
        {
            // Arrange
            var controller = CreateAccountController();

            // Act
            var result = controller.Logoff();

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result, "Redirect to route not returned.");
        }

        #endregion
    }
}
