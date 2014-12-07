using Geo.Raven;
using polymer.core.Database;
using polymer.databases.ravendb.Serialization.Nmoneys;
using Raven.Client;

namespace polymer.databases.ravendb
{
	public class RavenDbEmbeddedDatabaseContext : IRavenDbDatabaseContext
	{
		private readonly IDocumentStore _store;

		public RavenDbEmbeddedDatabaseContext(IDocumentStore store)
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