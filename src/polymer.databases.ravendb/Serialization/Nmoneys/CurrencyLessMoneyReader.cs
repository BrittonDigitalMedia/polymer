using System.Linq;
using NMoneys;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal class CurrencyLessMoneyReader : MoneyOperator, IMoneyReader
	{
		private readonly CurrencyIsoCode _defaultCurrency;

		public CurrencyLessMoneyReader(CurrencyIsoCode defaultCurrency, IContractResolver resolver) : base(resolver)
		{
			_defaultCurrency = defaultCurrency;
		}

		public decimal ReadAmount(JToken token)
		{
			return token.Type == JTokenType.Object && token.HasValues
				? token.Values().First().Value<decimal>()
				: token.Value<decimal>();
		}

		public CurrencyIsoCode ReadCurrencyCode(JToken token)
		{
			return _defaultCurrency;
		}
	}
}