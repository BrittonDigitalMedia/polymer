using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	/// <summary>
	/// Converts a <see cref="Money"/> instance from JSON numeric quantities.
	/// </summary>
	/// <remarks>To be used in integration scenarios when no currency can be provided and a default
	/// currency can be used.
	/// <para>
	/// Property casing must be configured apart from this converter using, for instance, another
	/// <see cref="IContractResolver"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4}</code>
	/// <code>{"any_other_name" : 123.4, ...}</code>
	/// </example>
	public class CurrencyLessMoneyConverter : JsonConverter
	{
		private readonly CurrencyIsoCode _defaultCurrency;

		public CurrencyLessMoneyConverter() : this(CurrencyIsoCode.XXX) { }

		public CurrencyLessMoneyConverter(CurrencyIsoCode defaultCurrency)
		{
			_defaultCurrency = defaultCurrency;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException(
				"Deserialization only. Moneys should never be serialized without currency information.");
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = JToken.ReadFrom(reader);

			IMoneyReader @default = new CurrencyLessMoneyReader(_defaultCurrency, serializer.ContractResolver);

			return new Money(
				@default.ReadAmount(token),
				@default.ReadCurrencyCode(token));
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof (Money);
		}
	}
}