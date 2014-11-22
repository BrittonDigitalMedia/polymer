using Machine.Specifications;
using Raven.Client.Embedded;
using Raven.Database.Config;

namespace polymer.tests.ravendb.for_DocumentStore
{
	public class when_creating_a_document_store
	{
		Establish context = () =>
		{
			_store = new EmbeddableDocumentStore { RunInMemory = true, Configuration = new RavenConfiguration { RunInMemory = true, RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true } };
		};

		Because of = () => _store.Initialize();

		Cleanup cleanup = () => _store.Dispose();

		It should_not_be_null = () => _store.ShouldNotBeNull();
		It should_open_session = () => _store.OpenSession().ShouldNotBeNull();

		private static EmbeddableDocumentStore _store;
	}
}