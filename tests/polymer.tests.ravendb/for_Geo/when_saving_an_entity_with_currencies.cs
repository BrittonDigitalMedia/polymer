using System;
using Geo.Geometries;
using Machine.Specifications;
using polymer.tests.ravendb.for_Geo.assets;
using polymer.tests.ravendb.for_Units.Net.given;

namespace polymer.tests.ravendb.for_Geo
{
	public class when_saving_an_entity_with_geo_info : a_valid_database_context
	{
		Establish context = () =>
		{
			_entity = new FakeEntityWithGeoProperties
			{
				Location = new Point(-26.130866, 28.173357),
				Key = Guid.NewGuid()
			};
		};

		Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity);
				uow.Commit();
			}

			using (var uow = _context.NewSession("TestDatabase"))
			{
				_resultEntity = uow.Get<FakeEntityWithGeoProperties>(_entity.Id);
			}

		};

		It should_have_entity_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithGeoProperties>(_entity.Id).ShouldNotBeNull();

		private It should_have_correct_currency_value = () => _resultEntity.Location.ShouldEqual(new Point(-26.130866, 28.173357));
		private static FakeEntityWithGeoProperties _entity;
		private static FakeEntityWithGeoProperties _resultEntity;
	}
}