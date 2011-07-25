using System.Collections.Generic;
using CCE.WebConnection.DAL.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public abstract class SQLRepository<T> : IRepository<T> where T : EntityBase2, IEntity2, new()
    {
        public T GetById(int id)
        {
            using (DataAccessAdapter adapter = new DataAccessAdapter())
            {
                return GetById(id, adapter);
            }
        }

        public abstract T GetById(int id, IDataAccessAdapter adapter);

        public IList<T> GetAll()
        {
            using (DataAccessAdapter adapter = new DataAccessAdapter())
            {
                return GetAll(adapter);
            }
        }

        public abstract IList<T> GetAll(IDataAccessAdapter adapter);

        public void Save(T entity)
        {
            using (DataAccessAdapter adapter = new DataAccessAdapter())
            {
                Save(entity, adapter);
            }
        }

        public virtual void Save(T entity, IDataAccessAdapter adapter)
        {
            entity.ValidateEntity();
            adapter.SaveEntity(entity, false, true);
        }

        public void Delete(T entity)
        {
            using (DataAccessAdapter adapter = new DataAccessAdapter())
            {
                Delete(entity, adapter);
            }
        }

        public virtual void Delete(T entity, IDataAccessAdapter adapter)
        {
            adapter.DeleteEntity(entity);
        }
    }
}
