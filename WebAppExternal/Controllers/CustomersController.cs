using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.BL.Repository.Abstract;

namespace CCE.WebConnection.WebAppExternal.Controllers
{
    /// <summary>
    /// The controller for the list page
    /// </summary>
    [HandleError]
    public class CustomersController : ControllerBase
    {
        #region Properties

        private ICustomersRepository customersRepository = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor takes an ICustomersRepository as an argument
        /// </summary>
        /// <param name="customersRepository">The customer repository to use</param>
        public CustomersController(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        #endregion

        // GET: /Customers/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Customers/Grid
        [Authorize]
        [OutputCache(Duration = 6000)]
        public ActionResult Grid()
        {
            //-- Get the list of customers
            IEnumerable<ICustomer> customers = customersRepository.GetAll();

            //-- Create a new view model to display
            CustomersViewModel customersViewModel = new CustomersViewModel(customers);

            //-- Show view
            return View(customersViewModel);
        }

        // GET: /Customers/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            //-- Get details of this customer
            ICustomer customer = customersRepository.GetByID(id);

            //-- Create customer view
            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            //-- Show view
            return View(customerViewModel);
        }

        // GET: /Customers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // Post: /Customers/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            customersRepository.Save(Mapper.Map<CustomerViewModel, ICustomer>(customerViewModel));
            return RedirectToAction("Grid", "Customers");
        }

        // GET: /Customers/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            //-- Get details of this customer
            ICustomer customer = customersRepository.GetByID(id);

            //-- Create customer view
            CustomerViewModel customerViewModel = new CustomerViewModel(customer);

            return View(customerViewModel);
        }

        // POST: /Customers/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return View(customerViewModel);

            customersRepository.Save(Mapper.Map<CustomerViewModel, ICustomer>(customerViewModel));

            return RedirectToAction("Details", "Customers", new { id = customerViewModel.PkId });
        }


        // DELETE: /Customers/Delete/5
        [HttpDelete]
        [Authorize]
        public ActionResult Delete(int id)
        {
            //-- Delete the item
            customersRepository.Delete(id);

            //-- Create a new view model to display
            CustomersViewModel customersViewModel = new CustomersViewModel(customersRepository.GetAll());

            return PartialView("PartialViews/_CustomerGrid", customersViewModel);
        }
    }
}
