using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal static class CurrencyStyleWriteExtensions
	{
		internal static void WriteValue(this JsonWriter writer, CurrencyIsoCode currency, CurrencyStyle style)
		{
			switch (style)
			{
				case CurrencyStyle.Alphabetic:
					writer.WriteValue(currency.AlphabeticCode());
					break;
				case CurrencyStyle.Numeric:
					writer.WriteValue(currency.NumericCode());
					break;
				default:
					throw new ArgumentOutOfRangeException("style");
			}
		}
	}
}