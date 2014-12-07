using Raven.Imports.Newtonsoft.Json;

namespace polymer.databases.ravendb.Serialization.Nmoneys
{
	internal interface IMoneyWriter
	{
		void WriteTo(JsonWriter writer);
	}
}