using System;
using polymer.core.Domain;

namespace polymer.tests.ravendb.for_RavenDb.assets
{
	public class FakeEntity : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public string TestProperty { get; set; }
	}
}