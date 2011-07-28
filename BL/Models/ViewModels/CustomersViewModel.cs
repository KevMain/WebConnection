using CCE.WebConnection.DAL.EntityClasses;
using MvcContrib.Pagination;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomersViewModel
    {
        public IPagination<CustomerEntity> Customers { get; private set; }

        public CustomersViewModel(IPagination<CustomerEntity> customers)
        {
            Customers = customers;
        }
    }
}
