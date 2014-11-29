using polymer.core.Domain;
using polymer.tests.testmodule.DomainObjects;

namespace polymer.tests.testmodule.EntityFactories
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