﻿using Geo.Raven;
using NMoneys.Serialization.Raven_DB;
using polymer.core.Database;
using Raven.Client;

namespace polymer.databases.ravendb
{
	public class RavenDbServerDatabaseContext : IRavenDbDatabaseContext
	{
		private readonly IDocumentStore _store;

		public RavenDbServerDatabaseContext(IDocumentStore store)
		{
			_store = store;
			_store.Conventions.CustomizeJsonSerializer = serializer => serializer.Converters.Add(new DefaultMoneyConverter());
			_store.ApplyGeoConventions();
			_store.Initialize();
		}

		public void Dispose()
		{
			_store.Dispose();
		}

		public IUnitOfWork NewSession(string databaseName)
		{
			return new RavenDbUnitOfWork(_store.OpenSession(databaseName));
		}
	}
}