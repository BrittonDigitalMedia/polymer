using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using polymer.tests.simpleinjector.for_SimpleInjectorContainer.assets;

namespace polymer.tests.simpleinjector.for_SimpleInjectorContainer
{
	public class when_scanning_for_implementations_of_an_interface : given.a_composed_container
	{
		Establish context = () => _container.FindAndInjectAll<IMuliImplInterface>();

		Because of = () =>
		{
			_instances = _simpleInjectorContainer.GetAllInstances<IMuliImplInterface>().ToList();
			_container_instances = _container.GetAllInstances<IMuliImplInterface>().ToList();
		};

		It should_return_four_instances = () => _instances.Count.ShouldEqual(4);
		It should_return_four_instances_through_container_wrapper = () => _container_instances.Count.ShouldEqual(4);

		private static List<IMuliImplInterface> _instances;
		private static List<IMuliImplInterface> _container_instances;
	}
}