using System.Collections.Generic;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.Domain.Concrete;
using CCE.WebConnection.BL.Models.ViewModels;

namespace CCE.WebConnection.Tests.Fakes
{
    public class FakeCustomerData
    {
        public static IList<ICustomer> CreateTestCustomers()
        {
            IList<ICustomer> customersList = new List<ICustomer>();

            //-- Add customers
            AddCustomer(ref customersList, 1, "Customer1");
            AddCustomer(ref customersList, 2, "Customer2");
            AddCustomer(ref customersList, 3, "Customer3");
            AddCustomer(ref customersList, 4, "Customer4");

            return customersList;
        }

        public static void AddCustomer(ref  IList<ICustomer> customers, int customerID, string customerName)
        {
            ICustomer customer = new Customer();
            customer.PkId = customerID;
            customer.Name = customerName;
            customers.Add(customer);
        }
    }
}
