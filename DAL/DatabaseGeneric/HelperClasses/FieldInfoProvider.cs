///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 25 July 2011 10:18:15
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.DAL.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (1 + 0));
			InitCustomerEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits CustomerEntity's FieldInfo objects</summary>
		private void InitCustomerEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CustomerFieldIndex), "CustomerEntity");
			this.AddElementFieldInfo("CustomerEntity", "Active", typeof(System.Boolean), false, false, false, false,  (int)CustomerFieldIndex.Active, 0, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CustomerFieldIndex.Created, 0, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)CustomerFieldIndex.CreatedBy, 50, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)CustomerFieldIndex.Deleted, 0, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Modified", typeof(System.DateTime), false, false, false, false,  (int)CustomerFieldIndex.Modified, 0, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "ModifiedBy", typeof(System.String), false, false, false, false,  (int)CustomerFieldIndex.ModifiedBy, 50, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Name", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Name, 100, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "PkId", typeof(System.Int32), true, false, true, false,  (int)CustomerFieldIndex.PkId, 0, 0, 10);
			this.AddElementFieldInfo("CustomerEntity", "TimeStamp", typeof(System.Byte[]), false, false, true, false,  (int)CustomerFieldIndex.TimeStamp, 2147483647, 0, 0);
		}
		
	}
}




