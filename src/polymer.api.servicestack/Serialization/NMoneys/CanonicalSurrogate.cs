using NMoneys;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	internal class CanonicalSurrogate : ISurrogate
	{
		public CanonicalSurrogate(Money from)
		{
			Amount = from.Amount;
			Currency = new CurrencySurrogate(from.CurrencyCode);
		}

		public decimal Amount { get; set; }
		public CurrencySurrogate Currency { get; set; }

		public class CurrencySurrogate
		{
			public CurrencySurrogate() { }

			public CurrencySurrogate(CurrencyIsoCode @from)
			{
				IsoCode = @from;
			}

			public CurrencyIsoCode IsoCode { get; set; }
		}

		public Money ToMoney()
		{
			return new Money(Amount, Currency.IsoCode);
		}
	}
}