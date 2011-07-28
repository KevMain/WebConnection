using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase2, IEntity2, new()
    {
        public IAdapterFactory AdapterFactory { get; set; }

        protected RepositoryBase(IAdapterFactory adapterFactory)
        {
            AdapterFactory = adapterFactory;
        }

        public T GetById(int id)
        {
            using (IDataAccessAdapter adapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                return GetById(id, adapter);
            }
        }

        public abstract T GetById(int id, IDataAccessAdapter adapter);

        public IList<T> GetAll()
        {
            using (IDataAccessAdapter adapter = AdapterFactory.GetNewSQLAdapterInstance())
            {
                return GetAll(adapter);
            }
        }

        public abstract IList<T> GetAll(IDataAccessAdapter adapter);

        public void Save(T entity)
        {
            using (IDataAccessAdapter adapter = AdapterFactory.GetNewSQLAdapterInstance())
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
            using (IDataAccessAdapter adapter = AdapterFactory.GetNewSQLAdapterInstance())
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
