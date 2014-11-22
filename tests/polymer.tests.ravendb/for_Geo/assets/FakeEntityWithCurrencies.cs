using System;
using Geo.Geometries;
using polymer.core.Domain;

namespace polymer.tests.ravendb.for_Geo.assets
{
	public class FakeEntityWithGeoProperties : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public Point Location { get; set; }
	}
}