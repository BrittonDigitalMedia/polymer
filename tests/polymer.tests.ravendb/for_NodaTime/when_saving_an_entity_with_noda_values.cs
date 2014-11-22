using Machine.Specifications;
using Moq;
using NodaTime;
using polymer.tests.ravendb.for_NodaTime.assets;
using It = Machine.Specifications.It;

namespace polymer.tests.ravendb.for_NodaTime
{
	public class when_saving_an_entity_with_noda_values : given.a_valid_database_context
	{
		Establish context = () =>
		{
			_fakeClock = new Mock<IClock>();
			_fakeClock.Setup(x => x.Now).Returns(() => Instant.FromUtc(2014, 1, 1, 11, 30));
			_entity = new FakeEntityWithNodaTimeProperties
			{
				Instant = _fakeClock.Object.Now,
				Time = new LocalTime(6, 15, 30),
				Date = new LocalDate(2014, 6, 15),
				ZonedDateTime = _fakeClock.Object.Now.InZone(DateTimeZoneProviders.Tzdb["Pacific/Fiji"])
			};
		};

		Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity);
				uow.Commit();
			}
		};

		It should_have_entity_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithNodaTimeProperties>(_entity.Id).ShouldNotBeNull();
		It should_have_correct_instant_stored = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithNodaTimeProperties>(_entity.Id).Instant.ShouldEqual(_fakeClock.Object.Now);
		It should_have_correct_time_stored = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithNodaTimeProperties>(_entity.Id).Time.ShouldEqual(new LocalTime(6, 15, 30));
		It should_have_correct_date_stored = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithNodaTimeProperties>(_entity.Id).Date.ShouldEqual(new LocalDate(2014, 6, 15));
		It should_have_correct_zoned_date_and_time_stored = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithNodaTimeProperties>(_entity.Id).ZonedDateTime.ShouldEqual(_fakeClock.Object.Now.InZone(DateTimeZoneProviders.Tzdb["Pacific/Fiji"]));

		private static FakeEntityWithNodaTimeProperties _entity;
		private static Mock<IClock> _fakeClock;
	}
}