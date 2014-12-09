using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	#region converters

	/// <summary>
	/// Converts a <see cref="Money"/> instance to and from JSON in the canonical way.
	/// </summary>
	/// <remarks>The canonical way is the one implemented in NMoneys itself, with an <c>Amount</c>
	/// numeric property and a <c>Currency</c> object with a three-letter code <c>IsoCode"</c> property.
	/// <para>
	/// Property casing must be configured apart from this converter using, for instance, another
	/// <see cref="IContractResolver"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4, "Currency" : {"IsoCode" : "XXX"}}</code>
	/// <code>{"amount" : 123.4, "currency" : {"isoCode" : "XXX"}}</code>
	/// </example>
	public class CanonicalMoneyConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var money = (Money) value;

			IMoneyWriter canonical = new CanonicalMoneyWriter(money, serializer.ContractResolver);
			canonical.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = JToken.ReadFrom(reader);

			var canonical = new CanonicalMoneyReader(serializer.ContractResolver as DefaultContractResolver);

			return new Money(
				canonical.ReadAmount(token),
				canonical.ReadCurrencyCode(token));
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof (Money);
		}
	}

	#endregion

	#region support for reading

	#endregion

	#region support for writing

	#endregion
}
