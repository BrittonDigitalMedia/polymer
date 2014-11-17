using System;

namespace polymer.core.Domain
{
	public interface IEntity
	{
		string Id { get; set; }
		Guid Key { get; set; }
	}
}