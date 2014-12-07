using NMoneys;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal class CanonicalMoneyReader : MoneyOperator, IMoneyReader
	{
		public CanonicalMoneyReader(IContractResolver resolver) : base(resolver)
		{
		}

		public decimal ReadAmount(JToken token)
		{
			return token[_amount].Value<decimal>();
		}

		public CurrencyIsoCode ReadCurrencyCode(JToken token)
		{
			JToken isoCode = token[_currency][_isoCode];
			return isoCode.GetValue(CurrencyStyle.Alphabetic);
		}
	}
}