using System.Linq;

namespace CCE.WebConnection.DAL.Abstract
{
    public interface IEntitiesModel
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<User> Users { get; }
        void SaveChanges();
        void Delete(object entity);
        void Add(object entity);
    }
}
