using NodaTime;
using polymer.core.Security;

namespace polymer.core.Logging
{
	public interface ILogRecord
	{
		Instant Timestamp { get; set; }
		LogLevel LogLevel { get; set; }
		LogType LogType { get; set; }
		string Details { get; set; }
		string Code { get; set; }
		IUserSession UserSession { get; set; }

	}
}