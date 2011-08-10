using System.Collections.Generic;
using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomersViewModel
    {
        public IList<CustomerViewModel> Customers { get; set; }

        public CustomersViewModel(IEnumerable<ICustomer> customers)
        {
            Customers = new List<CustomerViewModel>();
            foreach (ICustomer customer in customers)
            {
                Customers.Add(new CustomerViewModel(customer));
            }
        }
    }
}
