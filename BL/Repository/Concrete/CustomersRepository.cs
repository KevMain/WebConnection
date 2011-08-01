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

        public void Save(CustomerViewModel customerViewModel)
        {
            using (IDataAccessAdapter dataAccessAdapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                IQueryable<CustomerEntity> customer = (from c in new LinqMetaData(dataAccessAdapter).Customer where c.PkId == customerViewModel.CustomerID select c);
                CustomerEntity customerEntity = customer.Count() > 0 ? customer.Single() : new CustomerEntity();

                //-- Set field values
                customerEntity.Name = customerViewModel.CustomerName;

                //-- Set auto fields
                DAL.Llbl.HelperClasses.EntityUtils.UpdateAutoFields(customerEntity);
                
                dataAccessAdapter.SaveEntity(customerEntity, true, true);
            }
        }

        public void Delete(CustomerViewModel customerViewModel)
        {
            using (IDataAccessAdapter dataAccessAdapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                CustomerEntity customerEntity = (from c in new LinqMetaData(dataAccessAdapter).Customer where c.PkId == customerViewModel.CustomerID select c).Single();
                customerEntity.Name = customerViewModel.CustomerName;

                dataAccessAdapter.DeleteEntity(customerEntity);
            }
        }

        private CustomersViewModel ConvertToViewModel(IEnumerable<ICustomerEntity> customers)
        {
            IList<CustomerViewModel> customersList = customers.Select(customerEntity => new CustomerViewModel(customerEntity.PkId, customerEntity.Name)).ToList();
            return new CustomersViewModel(customersList);
        }
    }
}