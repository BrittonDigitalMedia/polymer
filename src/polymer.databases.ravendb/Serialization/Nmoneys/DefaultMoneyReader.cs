using NMoneys;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal class DefaultMoneyReader : MoneyOperator, IMoneyReader
	{
		private readonly CurrencyStyle _style;

		public DefaultMoneyReader(CurrencyStyle style, IContractResolver resolver)
			: base(resolver)
		{
			_style = style;
		}

		public decimal ReadAmount(JToken token)
		{
			return token[_amount].Value<decimal>();
		}

		public CurrencyIsoCode ReadCurrencyCode(JToken token)
		{
			JToken currency = token[_currency];
			return currency.GetValue(_style);
		}
	}
}