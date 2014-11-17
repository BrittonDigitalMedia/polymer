using NodaTime;
using polymer.core.Logging;
using polymer.core.Security;
using System;

namespace polymer.core.Commanding.Logging
{
	public class CommandLogRecord : ILogRecord
	{
		public CommandLogRecord(LogLevel logLevel, LogType logType, string details, string code, IUserSession userSession)
		{
			Code = code;
			UserSession = userSession;
			Details = details;
			LogType = logType;
			LogLevel = logLevel;
			Timestamp = SystemClock.Instance.Now;
		}

		public Instant Timestamp { get; set; }
		public LogLevel LogLevel { get; set; }
		public LogType LogType { get; set; }
		public string Details { get; set; }
		public string Code { get; set; }
		public IUserSession UserSession { get; set; }
		public ICommand Command { get; set; }
		public ICommandResult Result { get; set; }
		public Exception Exception { get; set; }
		public Instant Completed { get; set; }
	}
}