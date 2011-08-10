using System.Collections.Generic;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        public abstract IEnumerable<T> GetAll();

        public abstract T GetByID(int pkID);

        public abstract void Save(T entity);

        public abstract void Delete(int pkID);
    }
}
