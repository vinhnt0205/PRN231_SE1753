namespace WebAPI_Binding_Routing_Validation.Repositories
{
	public interface ILoggerManager
	{
		void LogInfo(string message);
		void LogWarn(string message);
		void LogDebug(string message);
		void LogError(string message);
	}
}
