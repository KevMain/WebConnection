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
            CustomerViewModel customerViewModel = customersRepository.GetByID(id);
            return View(customerViewModel);
        }
    }
}
