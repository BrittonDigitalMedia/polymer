using polymer.core.Domain;

namespace polymer.tests.endtoend.Module.DomainObjects
{
	public class PhoneNumber : IValueObject
	{
		public string Extension { get; set; }
		public string Number { get; set; }
	}
}