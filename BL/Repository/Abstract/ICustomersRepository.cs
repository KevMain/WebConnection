using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.DAL.EntityClasses;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface ICustomersRepository : IRepository<CustomerEntity>
    {
        CustomersViewModel GetByPageID(int? page);
    }
}

