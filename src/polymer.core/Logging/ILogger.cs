namespace polymer.core.Logging
{
	public interface ILogger
	{
		void LogInfo<TLogRecord>(TLogRecord logRecord) where TLogRecord : ILogRecord;
		void LogError<TLogRecord>(TLogRecord logRecord) where TLogRecord : ILogRecord;
		void LogWarning<TLogRecord>(TLogRecord logRecord) where TLogRecord : ILogRecord;
		void LogSecurity<TLogRecord>(TLogRecord logRecord) where TLogRecord : ILogRecord;
	}
}