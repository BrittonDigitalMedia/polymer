using polymer.core.Domain;
using polymer.tests.endtoend.Module.DomainObjects;

namespace polymer.tests.endtoend.Module.EntityFactories
{
	public class OrganisationFactory : IEntityFactory<Organisation>
	{
		public Organisation Create()
		{
			return new Organisation
			{
				
			};
		}
	}
}