using Machine.Specifications;
using polymer.specs.simpleinjector.for_SimpleInjectorContainer.assets;

namespace polymer.specs.simpleinjector.for_SimpleInjectorContainer
{
	public class when_injecting_an_instance_into_the_container : given.a_composed_container
	{
		Establish context = () =>
		{
			_instance1 = new FakeImplementation1();
			_container.Inject<IFakeInterface1>(_instance1);
		};

		Because of = () =>
		{
			_instance2 = _simpleInjectorContainer.GetInstance<IFakeInterface1>();
			_instance3 = _simpleInjectorContainer.GetInstance<IFakeInterface1>();
			_instance4 = _container.GetInstance<IFakeInterface1>();
		};

		It should_return_instance_of_correct_type = () => _instance2.ShouldBeOfExactType<FakeImplementation1>();
		It should_return_injected_instance = () => _instance2.ShouldEqual(_instance1);
		It should_return_injected_instance_the_second_time = () => _instance3.ShouldEqual(_instance1);
		It should_return_injected_instance_from_wrapped_container = () => _instance4.ShouldEqual(_instance1);


		private static FakeImplementation1 _instance1;
		private static IFakeInterface1 _instance2;
		private static IFakeInterface1 _instance3;
		private static IFakeInterface1 _instance4;
	}
}