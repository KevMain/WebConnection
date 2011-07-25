///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 25 July 2011 10:18:16
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.DAL.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass((1 + 0));
			InitCustomerEntityMappings();

		}


		/// <summary>Inits CustomerEntity's mappings</summary>
		private void InitCustomerEntityMappings()
		{
			this.AddElementMapping( "CustomerEntity", "WebConnection", @"dbo", "Customer", 9 );
			this.AddElementFieldMapping( "CustomerEntity", "Active", "Active", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 0 );
			this.AddElementFieldMapping( "CustomerEntity", "Created", "Created", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "CustomerEntity", "CreatedBy", "CreatedBy", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "CustomerEntity", "Deleted", "Deleted", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			this.AddElementFieldMapping( "CustomerEntity", "Modified", "Modified", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			this.AddElementFieldMapping( "CustomerEntity", "ModifiedBy", "ModifiedBy", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "CustomerEntity", "Name", "Name", true, "VarChar", 100, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "CustomerEntity", "PkId", "pk_ID", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 7 );
			this.AddElementFieldMapping( "CustomerEntity", "TimeStamp", "TimeStamp", false, "Timestamp", 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 8 );
		}

	}
}