using System.Web.Mvc;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.BL.Repository.Abstract;

namespace CCE.WebConnection.WebAppExternal.Controllers
{
    public class ListController : Controller
    {
        private ICustomersRepository customersRepository = null;

        public ListController(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public ActionResult ListCustomers(int? page)
        {
            CustomersViewModel customersViewModel = new CustomersViewModel(customersRepository.GetByPageID(page));
            return View(customersViewModel);
        }
    }
}
