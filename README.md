# Firewood

### Usage

#### Instantiating
```cs
using Firewood;

Logger log = new Logger(LogLevel.Info);
```

#### Basic usage
```cs
log.Log(LogLevel.Info, "Beans on toast?");
// Info: Beans on toast?

log.Log(LogLevel.Warn, "I do like beans on toast...");
// Warn: I do like beans on toast...

// this one won't show up because Info is lower than Trace
log.Log(LogLevel.Trace, "(but they don't know that.)");
// 
```

#### Logging with an owner class
```cs
class CustomTestClass {}
log.Log<CustomTestClass>(LogLevel.Info, "this one comes from somewhere!");
// Info: CustomTestClass: this one comes from somewhere!
```

#### Logging with time
This is the default time format. Time logging defaults to off.
```cs
// this is the default time format. time logging defaults to off.
Logger log = new Logger(LogLevel.Info, true, "HH:mm:ss");
log.Log(LogLevel.Info, "yes, I did write this readme at 4 am");
// [04:12:02] Info: yes, I did write this readme at 4 am
```

---

On Windows (at least, that's the only tested environment) the Warn line here will be in yellow. Error and Fatal are in red, and Trace is in blue.