using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal class CanonicalMoneyWriter : MoneyWriter
	{
		private readonly Money _instance;

		public CanonicalMoneyWriter(Money instance, IContractResolver resolver)
			: base(resolver)
		{
			_instance = instance;
		}

		protected override void writeAmount(JsonWriter writer)
		{
			writer.WritePropertyName(_amount);
			writer.WriteValue(_instance.Amount);
		}

		protected override void writeCurrency(JsonWriter writer)
		{
			writer.WritePropertyName(_currency);
			writer.WriteStartObject();
			writer.WritePropertyName(_isoCode);
			writer.WriteValue(_instance.CurrencyCode.AlphabeticCode());
			writer.WriteEndObject();
		}
	}
}