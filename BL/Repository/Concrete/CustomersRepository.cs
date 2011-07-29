using System;
using System.Collections.Generic;
using System.Linq;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL.EntityClasses;
using CCE.WebConnection.DAL.EntityContracts;
using CCE.WebConnection.DAL.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class CustomersRepository : ICustomersRepository 
    {
        public IAdapterFactory AdapterFactory { get; set; }

        public CustomersRepository(IAdapterFactory adapterFactory)
        {
            AdapterFactory = adapterFactory;
        }

        public CustomersViewModel GetAll()
        {
            using (IDataAccessAdapter dataAccessAdapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                IList<CustomerEntity> customers = (from c in new LinqMetaData(dataAccessAdapter).Customer orderby c.Name select c).ToList();
                return ConvertToViewModel(customers);
            }
        }

        public CustomerViewModel GetByID(int customerID)
        {
            using (IDataAccessAdapter dataAccessAdapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                CustomerEntity customer = (from c in new LinqMetaData(dataAccessAdapter).Customer where c.PkId == customerID select c).Single();
                return new CustomerViewModel(customer.PkId, customer.Name);
            }
        }

        private CustomersViewModel ConvertToViewModel(IEnumerable<ICustomerEntity> customers)
        {
            IList<CustomerViewModel> customersList = customers.Select(customerEntity => new CustomerViewModel(customerEntity.PkId, customerEntity.Name)).ToList();
            return new CustomersViewModel(customersList);
        }
    }
}