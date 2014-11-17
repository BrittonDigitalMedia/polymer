using System;
using Machine.Specifications;
using polymer.specs.ravendb.for_RavenDb.assets;

namespace polymer.specs.ravendb.for_RavenDb
{
	public class when_executing_multiple_operations_in_a_session : given.a_valid_database_context
	{
		Establish context = () =>
		{
			_entity1 = new FakeEntity { Key = Guid.NewGuid(), TestProperty = "Test1" };
			_entity2 = new FakeEntity { Key = Guid.NewGuid(), TestProperty = "Test2" };
			using (var session = _store.OpenSession("TestDatabase"))
			{
				session.Store(new FakeEntity { Id = "3", Key = Guid.NewGuid(), TestProperty = "Test3" });
				session.Store(new FakeEntity { Id = "4", Key = Guid.NewGuid(), TestProperty = "Test4" });
				session.SaveChanges();
			}
		};

		Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity1);
				uow.Store(_entity2);
				_entity3 = uow.Get<FakeEntity>("3");
				_entity3.TestProperty = "Updated Test 3";
				uow.Store(_entity3);
				_entity4 = uow.Get<FakeEntity>("4");
				uow.Delete<FakeEntity>(_entity4.Id);
				uow.Commit();
			}
		};

		It should_have_updated_id_for_entity_1 = () => _entity1.Id.ShouldNotBeNull();
		It should_have_updated_id_for_entity_2 = () => _entity2.Id.ShouldNotBeNull();
		It entity1_should_exist_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntity>(_entity1.Id).ShouldNotBeNull();
		It entity2_should_exist_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntity>(_entity2.Id).ShouldNotBeNull();
		It entity3_should_be_updated = () => _store.OpenSession("TestDatabase").Load<FakeEntity>(_entity3.Id).TestProperty.ShouldEqual("Updated Test 3");
		It entity4_should_no_longer_exist_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntity>(_entity4.Id).ShouldBeNull();

		private static FakeEntity _entity1;
		private static FakeEntity _entity2;
		private static FakeEntity _entity3;
		private static FakeEntity _entity4;
	}
}