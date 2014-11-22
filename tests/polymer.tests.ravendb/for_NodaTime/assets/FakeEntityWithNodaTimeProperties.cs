using System;
using NodaTime;
using polymer.core.Domain;

namespace polymer.tests.ravendb.for_NodaTime.assets
{
	public class FakeEntityWithNodaTimeProperties : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public Instant Instant { get; set; }
		public LocalDate Date { get; set; }
		public LocalTime Time { get; set; }
		public ZonedDateTime ZonedDateTime { get; set; }
	}
}