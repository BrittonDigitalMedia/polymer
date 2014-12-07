using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json.Linq;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal static class CurrencyStyleReadExtensions
	{
		internal static CurrencyIsoCode GetValue(this JToken token, CurrencyStyle style)
		{
			CurrencyIsoCode value;
			switch (style)
			{
				case CurrencyStyle.Alphabetic:
					var alphabetic = token.Value<string>();
					value = Currency.Code.Parse(alphabetic);
					break;
				case CurrencyStyle.Numeric:
					var numeric = token.Value<short>();
					value = Currency.Code.Cast(numeric);
					break;
				default:
					throw new ArgumentOutOfRangeException("style");
			}
			return value;
		}
	}
}