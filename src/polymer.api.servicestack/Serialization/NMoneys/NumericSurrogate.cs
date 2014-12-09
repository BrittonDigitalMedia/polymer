using NMoneys;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	internal class NumericSurrogate : ISurrogate
	{
		public NumericSurrogate(Money from)
		{
			Amount = from.Amount;
			Currency = from.CurrencyCode.NumericCode();
		}
		public decimal Amount { get; set; }
		public short Currency { get; set; }

		public Money ToMoney()
		{
			return new Money(Amount, global::NMoneys.Currency.Code.Cast(Currency));
		}
	}
}