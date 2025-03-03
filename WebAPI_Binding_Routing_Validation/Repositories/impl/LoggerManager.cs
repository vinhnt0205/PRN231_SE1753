namespace WebAPI_Binding_Routing_Validation.Repositories.impl
{
	public class LoggerManager : ILoggerManager
	{
		public void LogDebug(string message)
		{
			Console.WriteLine(message);
		}

		public void LogError(string message)
		{
			Console.WriteLine(message);
		}

		public void LogInfo(string message)
		{
			Console.WriteLine(message);
		}

		public void LogWarn(string message)
		{
			Console.WriteLine(message);
		}
	}
}
