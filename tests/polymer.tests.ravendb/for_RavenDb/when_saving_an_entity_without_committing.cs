using Machine.Specifications;
using polymer.tests.ravendb.for_RavenDb.assets;

namespace polymer.tests.ravendb.for_RavenDb
{
	public class when_saving_an_entity_without_committing : given.a_valid_database_context
	{
		Establish context = () => _entity = new FakeEntity();
		private static FakeEntity _entity;

		Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity);
			}
		};

		It should_have_updated_id = () => _entity.Id.ShouldNotBeNull();
		It should_not_exist_in_database = () => _store.OpenSession().Load<FakeEntity>(_entity.Id).ShouldBeNull();
	}
}