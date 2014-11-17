using Machine.Specifications;
using polymer.specs.simpleinjector.for_SimpleInjectorContainer.assets;

namespace polymer.specs.simpleinjector.for_SimpleInjectorContainer
{
	public class when_binding_an_interface_to_a_concrete_type : given.a_composed_container
	{
		Establish context = () => _container.Bind<IFakeInterface1, FakeImplementation1>();

		Because of = () =>
		{
			_instance1 = _simpleInjectorContainer.GetInstance<IFakeInterface1>();
			_instance2 = _simpleInjectorContainer.GetInstance<IFakeInterface1>();
			_instance3 = _container.GetInstance<IFakeInterface1>();
		};

		It should_return_correct_concrete_object = () => _instance1.ShouldBeOfExactType<FakeImplementation1>();
		It should_return_a_new_transient_instance_for_each_container_call = () => _instance1.ShouldNotEqual(_instance2);
		It should_return_correct_instance_through_container_wrapper = () => _instance3.ShouldBeOfExactType<FakeImplementation1>();

		private static IFakeInterface1 _instance1;
		private static IFakeInterface1 _instance2;
		private static IFakeInterface1 _instance3;
	}
}