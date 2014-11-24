using System.ComponentModel;
using System.Runtime.Serialization;

namespace polymer.core.Querying
{
	[DataContract(Namespace = "http://schemas.mosaic.co.za/types"), KnownType(typeof(ListItem))]
	public class ListItem : IListItem
	{
		[DataMember(Order = 0, IsRequired = true), Description("a unique id property which can be used to refer to the entity in question")]
		public string Id { get; set; }

		[DataMember(Order = 1, IsRequired = true), Description("a human-radable description of the entity")]
		public string DisplayName { get; set; }
	}
}