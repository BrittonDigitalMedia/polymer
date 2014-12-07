using polymer.core.Domain;
using polymer.tests.testmodule.DomainObjects;

namespace polymer.tests.testmodule.DomainFactories
{
	public class OrganisationFactory : IEntityFactory<Organisation>
	{
		private readonly IKeyGenerator _keyGenerator;

		public OrganisationFactory(IKeyGenerator keyGenerator)
		{
			_keyGenerator = keyGenerator;
		}

		public Organisation Create()
		{
			return new Organisation
			{
				Key = _keyGenerator.NewKey()
			};
		}
	}
}