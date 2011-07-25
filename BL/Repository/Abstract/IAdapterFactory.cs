using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface IAdapterFactory
    {
        IDataAccessAdapter GetNewSQLAdapterInstance();
    }
}
