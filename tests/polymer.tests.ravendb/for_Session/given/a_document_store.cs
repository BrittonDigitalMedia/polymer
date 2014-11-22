using Machine.Specifications;
using polymer.tests.ravendb._assets;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using Raven.Database.Config;

namespace polymer.tests.ravendb.for_Session.given
{
	public class a_document_store
	{
		Establish context = () =>
		{
			_store = new EmbeddableDocumentStore() { RunInMemory = true, Configuration = new RavenConfiguration { RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true, RunInMemory = true } };
			_store.Initialize();
			_store.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("Test");
			_class = new TestClass { TestProperty = "Test" };
		};

		Because of = () =>
		{
			using (var session = _store.OpenSession("Test"))
			{
				session.Store(_class);
				session.SaveChanges();
			}
		};

		It should_have_id_set = () => _class.Id.ShouldNotBeNull();
		It should_be_saved_in_database = () => _store.OpenSession("Test").Load<TestClass>(_class.Id).ShouldNotBeNull();


		Cleanup cleanup = () => _store.Dispose();
		private static EmbeddableDocumentStore _store;
		private static TestClass _class;
	}
}