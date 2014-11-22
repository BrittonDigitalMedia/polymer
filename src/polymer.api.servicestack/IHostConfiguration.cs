
namespace polymer.api.servicestack
{
	public interface IHostConfiguration
	{
		TType Get<TType>(string key);
		void Set(string key, object value);
	}
}