using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal class DefaultMoneyWriter : MoneyWriter
	{
		private readonly Money _instance;
		private readonly CurrencyStyle _style;

		public DefaultMoneyWriter(Money instance, CurrencyStyle style, IContractResolver resolver)
			: base(resolver)
		{
			_instance = instance;
			_style = style;
		}

		protected override void writeAmount(JsonWriter writer)
		{
			writer.WritePropertyName(_amount);
			writer.WriteValue(_instance.Amount);
		}

		protected override void writeCurrency(JsonWriter writer)
		{
			writer.WritePropertyName(_currency);
			writer.WriteValue(_instance.CurrencyCode, _style);
		}
	}
}