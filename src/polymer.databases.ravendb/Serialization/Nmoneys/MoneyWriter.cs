using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal abstract class MoneyWriter : MoneyOperator, IMoneyWriter
	{
		protected MoneyWriter(IContractResolver resolver) : base(resolver)
		{
		}

		public void WriteTo(JsonWriter writer)
		{
			writer.WriteStartObject();
			writeAmount(writer);
			writeCurrency(writer);
			writer.WriteEndObject();
		}

		protected abstract void writeAmount(JsonWriter writer);
		protected abstract void writeCurrency(JsonWriter writer);
	}
}