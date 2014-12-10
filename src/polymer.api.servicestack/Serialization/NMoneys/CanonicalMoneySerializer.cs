using NMoneys;
using ServiceStack.Text;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	#region serialization/deserialization functions

	/// <summary>
	/// Converts a <see cref="Money"/> instance to and from JSON in the canonical way.
	/// </summary>
	/// <remarks>The canonical way is the one implemented in NMoneys itself, with an <c>Amount</c>
	/// numeric property and a <c>Currency</c> object with a three-letter code <c>IsoCode"</c> property.
	/// <para>
	/// Property casing must be configured apart from this serializer using, for instance,
	/// <see cref="JsConfig.EmitCamelCaseNames"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4, "Currency" : {"IsoCode" : "XXX"}}</code>
	/// <code>{"amount" : 123.4, "currency" : {"isoCode" : "XXX"}}</code>
	/// </example>
	public static class CanonicalMoneySerializer
	{
		public static string Serialize(Money instance)
		{
			var surrogate = new CanonicalSurrogate(instance);
			return JsonSerializer.SerializeToString(surrogate);
		}

		public static Money Deserialize(string json)
		{
			var surrogate = JsonSerializer.DeserializeFromString<CanonicalSurrogate>(json);
			return surrogate.ToMoney();
		}
	}

	#endregion

}
