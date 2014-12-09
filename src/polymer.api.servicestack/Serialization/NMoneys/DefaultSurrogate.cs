using NMoneys;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	internal class DefaultSurrogate : ISurrogate
	{
		public DefaultSurrogate(Money from)
		{
			Amount = from.Amount;
			Currency = from.CurrencyCode;
		}

		public decimal Amount { get; set; }
		public CurrencyIsoCode Currency { get; set; }

		public Money ToMoney()
		{
			return new Money(Amount, Currency);
		}
	}
}