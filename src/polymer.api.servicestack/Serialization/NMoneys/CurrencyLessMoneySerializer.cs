using System.Globalization;
using System.Linq;
using NMoneys;
using ServiceStack.Text;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	/// <summary>
	/// Converts a <see cref="Money"/> instance from JSON numeric quantities.
	/// </summary>
	/// <remarks>To be used in integration scenarios when no currency can be provided and a default
	/// currency can be used.
	/// <para>
	/// Property casing must be configured apart from this serializer using, for instance,
	/// <see cref="JsConfig.EmitCamelCaseNames"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4}</code>
	/// <code>{"any_other_name" : 123.4, ...}</code>
	/// </example>
	public static class CurrencyLessMoneySerializer
	{
		public static Money Deserialize(string json)
		{
			JsonObject parsed = JsonObject.Parse(json);
			string instanceValue = parsed.Values.First();
			decimal amount = instanceValue == null
				? JsonSerializer.DeserializeFromString<decimal>(json)
				: decimal.Parse(instanceValue, NumberStyles.Number, CultureInfo.InvariantCulture);

			return new Money(amount);
		}
	}
}