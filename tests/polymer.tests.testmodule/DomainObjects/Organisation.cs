using System;
using polymer.core.Domain;

namespace polymer.tests.testmodule.DomainObjects
{
	public class Organisation : IEntity
	{
		internal Organisation()
		{
			
		}
		public string Id { get; set; }
		public Guid Key { get; set; }
	}
}