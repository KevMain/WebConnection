using CCE.WebConnection.DAL.EntityClasses;
using MvcContrib.Pagination;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface ICustomersRepository : IRepository<CustomerEntity>
    {
        IPagination<CustomerEntity> GetByPageID(int? page);
    }
}

