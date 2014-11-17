using Machine.Specifications;
using polymer.specs.ravendb.for_RavenDb.assets;

namespace polymer.specs.ravendb.for_RavenDb
{
	public class when_saving_an_entity : given.a_valid_database_context
	{
		private Establish context = () => _entity = new FakeEntity();
		private static FakeEntity _entity;

		private Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity);
				uow.Commit();
			}
		};

		private It should_have_updated_id = () => _entity.Id.ShouldNotBeNull();
		private It should_exist_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntity>(_entity.Id).ShouldNotBeNull();
	}
}