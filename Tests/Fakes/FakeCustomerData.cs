using System.Collections.Generic;
using CCE.WebConnection.BL.Models.ViewModels;

namespace CCE.WebConnection.Tests.Fakes
{
    public class FakeCustomerData
    {
        public static CustomersViewModel CreateTestCustomers()
        {
            IList<CustomerViewModel> customersList = new List<CustomerViewModel>();

            //-- Add customers
            AddCustomer(ref customersList, 1, "Customer1");
            AddCustomer(ref customersList, 2, "Customer2");
            AddCustomer(ref customersList, 3, "Customer3");
            AddCustomer(ref customersList, 4, "Customer4");

            return new CustomersViewModel(customersList);
        }

        public static void AddCustomer(ref  IList<CustomerViewModel> customers, int customerID, string customerName)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel(customerID, customerName);
            customers.Add(customerViewModel);
        }
    }
}
