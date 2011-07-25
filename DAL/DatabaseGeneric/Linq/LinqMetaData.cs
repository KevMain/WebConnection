///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 25 July 2011 10:18:15
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using CCE.WebConnection.DAL;
using CCE.WebConnection.DAL.EntityClasses;
using CCE.WebConnection.DAL.FactoryClasses;
using CCE.WebConnection.DAL.HelperClasses;
using CCE.WebConnection.DAL.RelationClasses;

namespace CCE.WebConnection.DAL.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((CCE.WebConnection.DAL.EntityType)typeOfEntity)
			{
				case CCE.WebConnection.DAL.EntityType.CustomerEntity:
					toReturn = this.Customer;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEntity instances in the database.</summary>
		public DataSource2<CustomerEntity> Customer
		{
			get { return new DataSource2<CustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}