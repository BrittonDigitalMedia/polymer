using System;
using Machine.Specifications;
using polymer.tests.ravendb.for_Units.Net.assets;
using UnitsNet;
using UnitsNet.Units;

namespace polymer.tests.ravendb.for_Units.Net
{
	public class when_saving_an_entity_with_units : given.a_valid_database_context
	{
		Establish context = () =>
		{
			_entity = new FakeEntityWithUnits
			{
				Area = Area.FromSquareMeters(30),
				Information = Information.FromGigabytes(2),
				Length = 100,
				LengthUnit = LengthUnit.Foot,
				Speed = Speed.FromKilometersPerHour(120),
				Weight = Mass.FromMilligrams(1500),
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
				_resultEntity = uow.Get<FakeEntityWithUnits>(_entity.Id);
			}

		};

		It should_have_entity_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithUnits>(_entity.Id).ShouldNotBeNull();

		private It should_have_correct_area_value =() => Length.From(_resultEntity.Length, _resultEntity.LengthUnit).ShouldEqual(Length.FromFeet(100));
		private static FakeEntityWithUnits _entity;
		private static FakeEntityWithUnits _resultEntity;
	}
}