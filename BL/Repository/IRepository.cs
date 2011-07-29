using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository
{
    public interface IRepository<T> where T : EntityBase2, IEntity2, new()
    {
        //T GetById(int id);
        //T GetById(int id, IDataAccessAdapter adapter);
        //IList<T> GetAll();
        //IList<T> GetAll(IDataAccessAdapter adapter);
        //void Save(T entity);
        //void Save(T entity, IDataAccessAdapter adapter);
        //void Delete(T entity);
        //void Delete(T entity, IDataAccessAdapter adapter);
    }
}