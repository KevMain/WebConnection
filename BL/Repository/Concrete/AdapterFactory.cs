using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class AdapterFactory : IAdapterFactory
    {
        public IDataAccessAdapter GetNewSQLAdapterInstance()
        {
            return new DataAccessAdapter();
        }
    }
}
