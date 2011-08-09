using System;
using System.Web.Mvc;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.ViewModels;

namespace CCE.WebConnection.WebAppExternal.Controllers
{
    public class AccountController : ControllerBase
    {
        #region Properties

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        #endregion

        #region Constructor

        public AccountController(IFormsAuthenticationService formsAuthenticationService, IMembershipService membershipService)
        {
            FormsService = formsAuthenticationService;
            MembershipService = membershipService;
        }

        #endregion

        //
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Customers");
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Logoff
        public ActionResult Logoff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }


        //
        // GET: /Account/ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(model.UserName, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess
        [HttpGet]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
