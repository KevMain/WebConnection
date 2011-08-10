using System.Collections.Generic;
using System.Linq;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL;
using CCE.WebConnection.DAL.Abstract;
using AutoMapper;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class CustomerRepository : ICustomersRepository
    {
        #region Properties

        public IEntitiesModel EntitiesModel { get; set; }
        private IMappingEngine MappingEngine { get; set; }

        #endregion

        public CustomerRepository(IEntitiesModel entitiesModel, IMappingEngine mappingEngine)
        {
            EntitiesModel = entitiesModel;
            MappingEngine = mappingEngine;
        }

        public IEnumerable<ICustomer> GetAll()
        {
            IQueryable<ICustomerEntity> customerEntities = from c in EntitiesModel.Customers select c;

            IList<ICustomer> customers = new List<ICustomer>();
            foreach (var customerEntity in customerEntities)
            {
                ICustomer customer = MappingEngine.Map<ICustomerEntity, ICustomer>(customerEntity);
                customers.Add(customer);
            }

            return customers;
        }

        public ICustomer GetByID(int customerID)
        {
            ICustomerEntity customerEntity = (from c in EntitiesModel.Customers where c.PkId == customerID select c).Single();
            return MappingEngine.Map<ICustomerEntity, ICustomer>(customerEntity);
        }

        public void Save(ICustomer customer)
        {
            IQueryable<ICustomerEntity> customers = (from c in EntitiesModel.Customers where c.PkId == customer.PkId select c);
            
            ICustomerEntity customerEntity;

            if(customers.Count() > 0)
            {
                customerEntity = customers.Single();
            }                   
            else
            {
                customerEntity = IoCManager.Container().Resolve<ICustomerEntity>();
                EntitiesModel.Add(customerEntity);
            }

            //-- Set details
            customerEntity.Name = customer.Name;

            //-- Save changes back to DB
            EntitiesModel.SaveChanges();
        }

        public void Delete(int customerID)
        {
            ICustomerEntity customerEntity = (from c in EntitiesModel.Customers where c.PkId == customerID select c).Single();
            EntitiesModel.Delete(customerEntity);
            EntitiesModel.SaveChanges();
        }
    }
}
