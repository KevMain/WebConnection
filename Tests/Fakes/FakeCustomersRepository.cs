using System.Collections.Generic;
using System.Linq;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.Domain.Concrete;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.BL.Repository.Abstract;

namespace CCE.WebConnection.Tests.Fakes
{
    public class FakeCustomersRepository : ICustomersRepository
    {
        private IList<ICustomer> customerList;

        public FakeCustomersRepository(IList<ICustomer> customers)
        {
            customerList = customers;
        }

        public IEnumerable<ICustomer> GetAll()
        {
            return customerList;
        }

        public ICustomer GetByID(int customerID)
        {
            return customerList.SingleOrDefault(c => c.PkId == customerID);
        }

        public void Save(ICustomer customer)
        {
            if (customer.Name == "Mr Smith")
            {
                ICustomer newCustomer = new Customer();
                newCustomer.PkId = 48;
                newCustomer.Name = "Mr Smith";

                customerList.Add(newCustomer);
            }
            else
            {
                customerList[0].Name = customer.Name;        
            }
        }

        public void Delete(int customerID)
        {
            customerList.RemoveAt(0);
        }
    }
}
