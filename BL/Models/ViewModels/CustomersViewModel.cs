using System.Collections.Generic;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomersViewModel
    {
        public IList<CustomerViewModel> Customers { get; set; }

        public CustomersViewModel(IList<CustomerViewModel> customers)
        {
            Customers = customers;
        }
    }
}
