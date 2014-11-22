using System;
using polymer.core.Domain;
using UnitsNet;
using UnitsNet.Units;

namespace polymer.tests.ravendb.for_Units.Net.assets
{
	public class FakeEntityWithUnits : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public Mass Weight { get; set; }
		public LengthUnit LengthUnit { get; set; }
		public double Length { get; set; }
		public Area Area { get; set; }
		public Information Information { get; set; }
		public Speed Speed { get; set; }
	}
}