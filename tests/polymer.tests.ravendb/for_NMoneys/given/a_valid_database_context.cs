﻿using Machine.Specifications;
using polymer.core.Database;
using polymer.databases.ravendb;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using Raven.Database.Config;
using Raven.Database.Server;

namespace polymer.tests.ravendb.for_NMoneys.given
{
	public class a_valid_database_context
	{
		Establish context = () =>
		{
			var embeddableStore = new EmbeddableDocumentStore { UseEmbeddedHttpServer = true, RunInMemory = true, Configuration = new RavenConfiguration { RunInMemory = true, RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true } };
			NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8081);
			_store = embeddableStore;
			//_store = new DocumentStore {Url = "http://localhost:8081"};
			_store.Initialize();
			_context = new RavenDbEmbeddedDatabaseContext(_store);
			_store.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("TestDatabase");
		};



		//Cleanup after = () => _testbase.Dispose();

		protected static IDocumentStore _store;
		protected static IDatabaseContext _context;
	}
}