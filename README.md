# TacitusLogger.Contributors.ThreadInfo

> Extension contributor for TacitusLogger that generates additional info related to the thread on which the logger method was called.
 
Dependencies:  
* .Net Standard >= 2.0  
* TacitusLogger >= 0.2.0  
  
> Attention: `TacitusLogger.Contributors.ThreadInfo` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="http://example.com/" target="_blank">package</a>:

```powershell
PM> Install-Package TacitusLogger.Contributors.ThreadInfo
```

## Examples

### Adding thread info contributor to the logger
With builders:
```cs
Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .ThreadInfo()
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
ThreadInfoContributor threadInfo = new ThreadInfoContributor();

Logger logger = new Logger();
logger.AddLogContributor(threadInfo);
```
---
### Explicitly specifying name and status of thread info contributor
With builders:
```cs
Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .ThreadInfo(true, "Thread")
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
ThreadInfoContributor threadInfo = new ThreadInfoContributor("Thread");
threadInfo.SetActive(true);

Logger logger = new Logger();
logger.AddLogContributor(threadInfo);
```
---
### Explicitly specifying mutable status of thread info contributor
With builders:
```cs
Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .ThreadInfo(status)
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
MutableSetting<bool> status = Setting<bool>.From.Variable(true);
ThreadInfoContributor threadInfo = new ThreadInfoContributor("Thread");
threadInfo.SetActive(status);

Logger logger = new Logger();
logger.AddLogContributor(threadInfo);
```