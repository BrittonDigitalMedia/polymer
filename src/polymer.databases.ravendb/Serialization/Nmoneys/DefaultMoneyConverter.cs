using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	/// <summary>
	/// Converts a <see cref="Money"/> instance to and from JSON in a default (standard) way.
	/// </summary>
	/// <remarks>The default (standard) way is the one that a normal serializer would do for a money instance,
	/// with an <c>Amount</c> numeric property and a <c>Currency</c> code. The <c>Currency</c> property can be
	/// serialized either as a string (the default or providing <see cref="CurrencyStyle.Alphabetic"/>) or as
	/// a number (providing <see cref="CurrencyStyle.Numeric"/>).
	/// <para>
	/// Property casing must be configured apart from this converter using, for instance, another
	/// <see cref="IContractResolver"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4, "Currency" : "XXX"}</code>
	/// <code>{"amount" : 123.4, "currency" : 999}</code>
	/// </example>
	public class DefaultMoneyConverter : JsonConverter
	{
		private readonly CurrencyStyle _style;

		public DefaultMoneyConverter() : this(CurrencyStyle.Alphabetic)
		{
		}

		public DefaultMoneyConverter(CurrencyStyle style)
		{
			_style = style;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var instance = (Money) value;

			IMoneyWriter @default = new DefaultMoneyWriter(instance, _style, serializer.ContractResolver);
			@default.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = JToken.ReadFrom(reader);

			IMoneyReader @default = new DefaultMoneyReader(_style, serializer.ContractResolver);

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