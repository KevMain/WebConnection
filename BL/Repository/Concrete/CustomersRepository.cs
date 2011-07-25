using System;
using System.Collections.Generic;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL.EntityClasses;
using CCE.WebConnection.DAL.FactoryClasses;
using CCE.WebConnection.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class CustomersRepository : SQLRepository<CustomerEntity>, ICustomersRepository 
    {
        public override CustomerEntity GetById(int customerID, IDataAccessAdapter adapter)
        {
            CustomerEntity customerEntity = new CustomerEntity(customerID);
            adapter.FetchEntity(customerEntity);

            return customerEntity;
        }

        public override IList<CustomerEntity> GetAll(IDataAccessAdapter adapter)
        {
            EntityCollection<CustomerEntity> customers = new EntityCollection<CustomerEntity>(new CustomerEntityFactory());
            adapter.FetchEntityCollection(customers, null);

            return customers;
        }
    }
}