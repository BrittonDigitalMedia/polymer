using polymer.core.Domain;
using polymer.tests.testmodule.DomainObjects;

namespace polymer.tests.testmodule.EntityFactories
{
	public class EmployeeFactory : IEntityFactory<Employee>
	{
		private readonly Organisation _employer;

		public EmployeeFactory(Organisation employer)
		{
			_employer = employer;
		}

		public Employee Create()
		{
			return new Employee
			{
				OrganisationId = _employer.Id
			};
		}
	}
}