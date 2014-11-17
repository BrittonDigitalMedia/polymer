using System;

namespace polymer.core.Domain
{
	public interface IKeyGenerator
	{
		Guid NewKey();
	}
}