using System;
using System.Collections.Generic;
using System.Linq;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL.DatabaseSpecific;
using CCE.WebConnection.DAL.EntityClasses;
using CCE.WebConnection.DAL.Linq;
using MvcContrib.Pagination;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class CustomersRepository : SQLRepository<CustomerEntity>, ICustomersRepository 
    {
        public override CustomerEntity GetById(int customerID, IDataAccessAdapter adapter)
        {
            return (from c in new LinqMetaData(adapter).Customer where c.PkId == customerID select c).Single();
        }

        public override IList<CustomerEntity> GetAll(IDataAccessAdapter adapter)
        {
            throw new NotImplementedException();
        }

        public IPagination<CustomerEntity> GetByPageID(int? page)
        {
            using (DataAccessAdapter adapter = new DataAccessAdapter())
            {
                var customers = (from c in new LinqMetaData(adapter).Customer orderby c.Name select c).AsPagination(page ?? 1, 10);
                var totalPages = customers.TotalPages; //HACK: find a better way to do this
                return customers;
            }
        }
    }
}