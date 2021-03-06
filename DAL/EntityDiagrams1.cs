﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;


namespace CCE.WebConnection.DAL	
{
	public partial class EntitiesModel : OpenAccessContext, CCE.WebConnection.DAL.Abstract.IEntitiesModel
	{
		private static string connectionStringName = @"Connection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
		
			
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntityDiagrams1.rlinq");
	
		public EntitiesModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public EntitiesModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
	
		public EntitiesModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public EntitiesModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public EntitiesModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
<<<<<<< HEAD
		public IQueryable<User> Users 
		{
	    	get
	    	{
	        	return this.GetAll<User>();
	    	}
		}
		
		public IQueryable<Customer> Customers 
		{
	    	get
	    	{
	        	return this.GetAll<Customer>();
=======
		public IQueryable<Customer> Customers 
		{
	    	get
	    	{
	        	return this.GetAll<Customer>();
	    	}
		}
		
		public IQueryable<User> Users 
		{
	    	get
	    	{
	        	return this.GetAll<User>();
>>>>>>> 34ef6c6b94c7b04c4eb3cd4bb3a10d0f43d3542c
	    	}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "ads";
			backend.ProviderName = "Advantage.Data.Provider";
			return backend;
		}
	}
}
#pragma warning restore 1591

