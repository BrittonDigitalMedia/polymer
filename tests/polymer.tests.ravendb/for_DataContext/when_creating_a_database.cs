using Machine.Specifications;
using polymer.databases.ravendb;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using Raven.Database.Config;

namespace polymer.tests.ravendb.for_DataContext
{
	public class when_creating_a_context
	{
		Establish context = () =>
		{
			_store = new EmbeddableDocumentStore { RunInMemory = true, Configuration = new RavenConfiguration { RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true, RunInMemory = true } };


		};

		Because of = () =>
		{
			_context = new RavenDbEmbeddedDatabaseContext(_store);
			_store.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("TestDatabase");
		};

		It should_not_be_null = () => _context.ShouldNotBeNull();
		It should_open_uow = () => _context.NewSession("TestDatabase").ShouldNotBeNull();

		private static EmbeddableDocumentStore _store;
		private static RavenDbEmbeddedDatabaseContext _context;
	}
}