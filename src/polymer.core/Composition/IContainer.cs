
using System.Collections.Generic;

namespace polymer.core.Composition
{
	public interface IContainer
	{
		void Bind<TInterface, TConcreteType>(ObjectLifespan lifespan = ObjectLifespan.Transient)
			where TInterface : class
			where TConcreteType : class, TInterface;

		void Inject<TInterface>(TInterface instance)
			where TInterface : class;
		void FindAndInjectAll<TInterface>();
		T GetInstance<T>() where T : class;
		IEnumerable<T> GetAllInstances<T>() where T : class;
	}
}