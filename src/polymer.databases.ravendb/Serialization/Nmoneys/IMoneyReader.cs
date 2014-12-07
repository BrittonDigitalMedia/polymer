using NMoneys;
using Raven.Imports.Newtonsoft.Json.Linq;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal interface IMoneyReader
	{
		decimal ReadAmount(JToken token);
		CurrencyIsoCode ReadCurrencyCode(JToken token);
	}
}