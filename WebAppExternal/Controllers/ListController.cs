using System.Collections.Generic;
using System.Web.Mvc;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL.EntityClasses;

namespace CCE.WebConnection.WebAppExternal.Controllers
{
    public class ListController : Controller
    {
        private ICustomersRepository customersRepository = null;
        private IAdapterFactory adapterFactory = null;

        public ListController(ICustomersRepository customersRepository, IAdapterFactory adapterFactory)
        {
            this.customersRepository = customersRepository;
            this.adapterFactory = adapterFactory;
        }

        public ActionResult ListCustomers()
        {
            IList<CustomerEntity> customers = customersRepository.GetAll(adapterFactory.GetNewSQLAdapterInstance());
            return View(customers);
        }
    }
}
