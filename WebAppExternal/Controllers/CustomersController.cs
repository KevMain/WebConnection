using System;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Customers/Grid
        public ActionResult Grid()
        {
            return View(customersRepository.GetAll());
        }

        // GET: /Customers/Details/5
        public ActionResult Details(int id)
        {
            return View(customersRepository.GetByID(id));
        }

        // GET: /Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: /Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return View();

           customersRepository.Save(customerViewModel);
            return RedirectToAction("Grid", "Customers");
        }

        // GET: /Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customersRepository.GetByID(id));
        }

        // POST: /Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return View(customerViewModel);

            customersRepository.Save(customerViewModel);
            return RedirectToAction("Details", "Customers", new { id = customerViewModel.CustomerID });
        }

        // GET: /Customers/Delete/5
        public ActionResult Delete(int id)
        {
            customersRepository.Delete(customersRepository.GetByID(id));
            return RedirectToAction("Grid", "Customers");
        }
    }
}
