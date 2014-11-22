using System;
using NMoneys;
using polymer.core.Domain;

namespace polymer.tests.ravendb.for_NMoneys.assets
{
	public class FakeEntityWithCurrencies : IEntity
	{
		public string Id { get; set; }
		public Guid Key { get; set; }
		public Money TransactionAmount { get; set; }
	}
}