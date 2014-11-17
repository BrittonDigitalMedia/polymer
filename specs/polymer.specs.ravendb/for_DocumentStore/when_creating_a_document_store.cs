using Machine.Specifications;
using Raven.Client.Embedded;
using Raven.Database.Config;
using Raven.Tests.Helpers;

namespace polymer.specs.ravendb.for_DocumentStore
{
	public class when_creating_a_document_store
	{
		Establish context = () =>
		{
			_testBase = new TestBase();
			_store = _testBase.NewDocumentStore();
		};

		Because of = () => _store.Initialize();

		Cleanup cleanup = () => _testBase.Dispose();

		It should_not_be_null = () => _store.ShouldNotBeNull();
		It should_open_session = () => _store.OpenSession().ShouldNotBeNull();

		private static EmbeddableDocumentStore _store;
		private static TestBase _testBase;
	}
}