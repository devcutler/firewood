using System.Runtime.Serialization;

namespace Firewood;

public class Logger(LogLevel level, bool logTime = false, string? timeFormat = null)
{
	public Dictionary<LogLevel, ConsoleColor> Colors = new()
	{
		{ LogLevel.Trace, ConsoleColor.Blue },
		{ LogLevel.Debug, Console.ForegroundColor },
		{ LogLevel.Info, Console.ForegroundColor },
		{ LogLevel.Warn, ConsoleColor.DarkYellow },
		{ LogLevel.Error, ConsoleColor.Red },
		{ LogLevel.Fatal, ConsoleColor.Red }
	};

	public LogLevel Level = level;

	public string? TimeFormat = timeFormat;
	public bool EnableTime = logTime;

	private string? GetFormattedTime(DateTime? time = null)
	{
		if (!EnableTime)
		{
			return null;
		}
		if (TimeFormat != null)
		{
			return (time ?? DateTime.Now).ToString(TimeFormat);
		}
		return (time ?? DateTime.Now).ToString("HH:mm:ss");
	}

	public void Log(LogLevel level, string message)
	{
		if (level < Level) { return; }
		WriteLog(level, null, message, GetFormattedTime());
	}
	public void Log<T>(LogLevel level, string message)
	{
		if (level < Level) { return; }
		WriteLog(level, typeof(T), message, GetFormattedTime());
	}

	private void WriteLog(LogLevel level, Type? owner, string message, string? time)
	{
		if (time != null)
		{
			Write(time + ' ', null);
		}
		Write(level.ToString(), Colors[level]);
		Write(": ", null);
		if (owner != null)
		{
			if (owner.IsSubclassOf(typeof(Exception)))
			{
				Write(owner.Name, Colors[LogLevel.Error]);
			}
			else
			{
				Write(owner.Name, null);
			}
			Write(": ", null);
		}
		Write(message, Colors[level], true);
	}
	private static void Write(string data, ConsoleColor? color, bool endLine = false)
	{
		Console.ResetColor();
		Console.ForegroundColor = color ?? Console.ForegroundColor;
		Console.Write(data);
		if (endLine)
		{
			Console.WriteLine();
		}
		Console.ResetColor();
	}
}