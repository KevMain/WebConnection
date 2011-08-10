using System.Collections.Generic;

namespace CCE.WebConnection.BL.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int pkID);
        void Save(T entity);
        void Delete(int pkID);
    }
}