using NMoneys;
using polymer.core.Domain;
using System;

namespace polymer.specs.ravendb.for_NMoneys.assets
{
	public class FakeEntityWithCurrencies : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public Money TransactionAmount { get; set; }
	}
}