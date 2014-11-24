using System;
using System.Collections.Generic;
using polymer.core.Domain;

namespace polymer.tests.endtoend.Module.DomainObjects
{
	public class Employee : IEntity
	{
		internal Employee()
		{

		}
		public string Id { get; set; }
		public Guid Key { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string OrganisationId { get; set; }

		public string ManagerEmployeeId { get; set; }

		public List<PhoneNumber> PhoneNumbers { get; set; }
	}
}