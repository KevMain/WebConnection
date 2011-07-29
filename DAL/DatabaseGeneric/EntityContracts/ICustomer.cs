 ////////////////////////////////////////////////////////////////////////////////////////////////////////
// This is generated code. 
////////////////////////////////////////////////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 29 July 2011 08:58:36
// Code is generated using templates: CCE Custom Bindings
// Templates version: 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using CCE.WebConnection.DAL.EntityClasses;

namespace CCE.WebConnection.DAL.EntityContracts
{
    /// <summary>
    /// Interface for the entity 'Customer'.
    /// </summary>
    public partial interface ICustomerEntity 
    {
		System.Boolean Active {get;set;}
		System.DateTime Created {get;set;}
		System.String CreatedBy {get;set;}
		System.Boolean Deleted {get;set;}
		System.DateTime Modified {get;set;}
		System.String ModifiedBy {get;set;}
		System.String Name {get;set;}
		System.Int32 PkId {get;set;}
		System.Byte[] TimeStamp {get;}
    }
}
