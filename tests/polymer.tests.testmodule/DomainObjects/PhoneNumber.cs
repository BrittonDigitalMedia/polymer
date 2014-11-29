using polymer.core.Domain;

namespace polymer.tests.testmodule.DomainObjects
{
	public class PhoneNumber : IValueObject
	{
		public string Extension { get; set; }
		public string Number { get; set; }
	}
}