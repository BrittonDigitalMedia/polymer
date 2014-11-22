using Machine.Specifications;
using polymer.core.Database;
using polymer.databases.ravendb;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using Raven.Database.Config;

namespace polymer.tests.ravendb.for_RavenDb.given
{
	public class a_valid_database_context
	{
		Establish context = () =>
		{
			var embeddableStore = new EmbeddableDocumentStore { RunInMemory = true, Configuration = new RavenConfiguration { RunInMemory = true, RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true } };
			embeddableStore.Initialize();
			embeddableStore.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("TestDatabase");
			_store = embeddableStore;
			_context = new RavenDbEmbeddedDatabaseContext(_store);
		};



		//Cleanup after = () => _testbase.Dispose();

		protected static IDocumentStore _store;
		protected static IDatabaseContext _context;
	}
}