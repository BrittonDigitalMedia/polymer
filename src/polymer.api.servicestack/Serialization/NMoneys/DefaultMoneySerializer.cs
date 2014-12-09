using NMoneys;
using ServiceStack.Text;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	/// <summary>
	/// Converts a <see cref="Money"/> instance to and from JSON in a default (standard) way.
	/// </summary>
	/// <remarks>The default (standard) way is the one that a normal serializer would do for a money instance,
	/// with an <c>Amount</c> numeric property and an alphabetical <c>Currency</c> code.
	/// <para>
	/// Property casing must be configured apart from this serializer using, for instance,
	/// <see cref="JsConfig.EmitCamelCaseNames"/>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>{"Amount" : 123.4, "Currency" : "XXX"}</code>
	/// </example>
	public static class DefaultMoneySerializer
	{
		public static string Serialize(Money instance)
		{
			var surrogate = new DefaultSurrogate(instance);
			return JsonSerializer.SerializeToString(surrogate);
		}

		public static Money Deserialize(string json)
		{
			var proxy = JsonSerializer.DeserializeFromString<DefaultSurrogate>(json);
			return proxy.ToMoney();
		}

		/// <summary>
		/// Converts a <see cref="Money"/> instance to and from JSON in a default (standard) way.
		/// </summary>
		/// <remarks>The default (standard) way is the one that a normal serializer would do for a money instance,
		/// with an <c>Amount</c> numeric property and a numerical <c>Currency</c> code.
		/// <para>
		/// Property casing must be configured apart from this serializer using, for instance,
		/// <see cref="JsConfig.EmitCamelCaseNames"/>
		/// </para>
		/// </remarks>
		/// <example>
		/// <code>{"Amount" : 123.4, "Currency" : 999}</code>
		/// </example>
		public static class Numeric
		{
			public static string Serialize(Money instance)
			{
				var surrogate = new NumericSurrogate(instance);
				return JsonSerializer.SerializeToString(surrogate);
			}

			public static Money Deserialize(string json)
			{
				var proxy = JsonSerializer.DeserializeFromString<NumericSurrogate>(json);
				return proxy.ToMoney();
			}
		}
	}
}