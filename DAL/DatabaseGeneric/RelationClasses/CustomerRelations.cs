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
using System.Collections;
using System.Collections.Generic;
using CCE.WebConnection.DAL;
using CCE.WebConnection.DAL.FactoryClasses;
using CCE.WebConnection.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Customer. </summary>
	public partial class CustomerRelations
	{
		/// <summary>CTor</summary>
		public CustomerRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCustomerRelations
	{

		/// <summary>CTor</summary>
		static StaticCustomerRelations()
		{
		}
	}
}
