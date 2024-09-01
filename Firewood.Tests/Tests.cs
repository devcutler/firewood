using Firewood;

class TestOwningType
{

}

internal class Program
{
	class CustomTestClass { }
	private static void Main()
	{
		Logger log = new Logger(LogLevel.Info, true, "[HH:mm:ss]");

		// logs at the default level, same as the cutoff set above
		log.Log(LogLevel.Info, "Beans on toast?");

		log.Log(LogLevel.Warn, "I do like beans on toast...");

		// this one won't show up because Info is lower than Trace
		log.Log(LogLevel.Trace, "(but they don't know that.)");

		log.Log<CustomTestClass>(LogLevel.Error, "this one comes from somewhere!");

		log.Log(LogLevel.Info, "yes, I did write this readme at 4 am");

		return;

		string traceMessage = "super detailed tracing information";
		string debugMessage = "debug info, like variable values";
		string infoMessage = "for general happenings of the program";
		string warningMessage = "a warning about something that isn't quite right";
		string errorMessage = "the program had a problem, but can continue";
		string fatalMessage = "there was something so wrong the program had to stop";
		foreach (LogLevel level in Enum.GetValues(typeof(LogLevel)))
		{
			Console.WriteLine("Logging for LogLevel " + level + ".");
			Console.WriteLine("Only logs of level " + level + " or more significant should show here.");
			Logger logger = new(level);

			logger.Log(LogLevel.Trace, traceMessage);
			logger.Log(LogLevel.Debug, debugMessage);
			logger.Log(LogLevel.Info, infoMessage);
			logger.Log(LogLevel.Warn, warningMessage);
			logger.Log(LogLevel.Error, errorMessage);
			logger.Log(LogLevel.Fatal, fatalMessage);

			logger.Log<TestOwningType>(LogLevel.Trace, traceMessage);
			logger.Log<TestOwningType>(LogLevel.Debug, debugMessage);
			logger.Log<TestOwningType>(LogLevel.Info, infoMessage);
			logger.Log<TestOwningType>(LogLevel.Warn, warningMessage);
			logger.Log<TestOwningType>(LogLevel.Error, errorMessage);
			logger.Log<TestOwningType>(LogLevel.Fatal, fatalMessage);
		}
	}
}