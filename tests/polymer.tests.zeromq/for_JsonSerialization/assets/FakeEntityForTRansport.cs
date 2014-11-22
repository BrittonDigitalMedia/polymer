using System;
using System.Collections.Generic;
using polymer.core.Domain;

namespace polymer.tests.zeromq.for_JsonSerialization.assets
{
	public class FakeEntityForTransport : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public double DoubleProperty { get; set; }
		public List<string> ListOfStrings { get; set; } 

	}
}