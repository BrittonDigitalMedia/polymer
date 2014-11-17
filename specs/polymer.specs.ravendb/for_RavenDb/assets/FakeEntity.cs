using polymer.core.Domain;
using System;

namespace polymer.specs.ravendb.for_RavenDb.assets
{
	public class FakeEntity : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public string TestProperty { get; set; }
	}
}