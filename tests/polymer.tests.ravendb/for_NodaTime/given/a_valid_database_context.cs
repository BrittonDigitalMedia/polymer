using Machine.Specifications;
using polymer.core.Database;
using polymer.databases.ravendb;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using Raven.Database.Config;

namespace polymer.tests.ravendb.for_NodaTime.given
{
	public class a_valid_database_context
	{
		Establish context = () =>
		{
			var embeddableStore = new EmbeddableDocumentStore { RunInMemory = true, Configuration = new RavenConfiguration { RunInMemory = true, RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true } };

			_store = embeddableStore;
			_context = new RavenDbEmbeddedDatabaseContext(_store);
			embeddableStore.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("TestDatabase");
		};



		//Cleanup after = () => _testbase.Dispose();

		protected static IDocumentStore _store;
		protected static IDatabaseContext _context;
	}
}