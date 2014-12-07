using polymer.core.Guids;
using System;

namespace polymer.core.Domain
{
	public class CombGuidKeyGenerator : IKeyGenerator
	{
		public Guid NewKey()
		{
			return SequentialGuid.Create();
		}
	}
}