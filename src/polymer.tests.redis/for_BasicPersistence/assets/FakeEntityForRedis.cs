using polymer.core.Domain;
using System;

namespace polymer.tests.redis.for_BasicPersistence.assets
{
	public class FakeEntityForRedis : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }

		public double TestDouble { get; set; }

		public DateTime TestDateTime { get; set; }

		public string Name { get; set; }
	}
}