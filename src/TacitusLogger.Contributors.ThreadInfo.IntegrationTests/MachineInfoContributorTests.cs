using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TacitusLogger.Builders;
using TacitusLogger.Destinations;

namespace TacitusLogger.Contributors.ThreadInfo.IntegrationTests
{
    [TestFixture]
    public class ThreadInfoContributorTests
    {
        [Test]
        public void Logger_Containing_Thread_Info_Log_Contributors_And_One_Log_Group_With_Several_Custom_Destinations()
        {
            // Arrange 
            // Build logger with two log groups
            var logDestination1Mock = new Mock<ILogDestination>();
            var logDestination2Mock = new Mock<ILogDestination>();
            Logger logger = (Logger)LoggerBuilder.Logger().Contributors()
                                                              .ThreadInfo(true, "Machine")
                                                              .BuildContributors()
                                                          .NewLogGroup()
                                                          .ForAllLogs()
                                                              .CustomDestination(logDestination1Mock.Object)
                                                              .CustomDestination(logDestination2Mock.Object)
                                                          .BuildLogGroup()
                                                          .BuildLogger();
            // Act
            logger.Log("context1", LogType.Event, "Description", new { });

            // Assert  
            logDestination1Mock.Verify(x => x.Send(It.Is<LogModel[]>(d => d.Length == 1 &&
                                                                          d[0].LogItems.FirstOrDefault(a => a.Name == "Machine") != null)), Times.Once);
            logDestination2Mock.Verify(x => x.Send(It.Is<LogModel[]>(d => d.Length == 1 &&
                                                                          d[0].LogItems.FirstOrDefault(a => a.Name == "Machine") != null)), Times.Once);
        }
        [Test]
        public async Task Async_Logger_Containing_Thread_Info_Log_Contributors_And_One_Log_Group_With_Several_Custom_Destinations()
        {
            // Arrange 
            // Build logger with two log groups
            var logDestination1Mock = new Mock<ILogDestination>();
            var logDestination2Mock = new Mock<ILogDestination>();
            Logger logger = (Logger)LoggerBuilder.Logger().Contributors()
                                                              .ThreadInfo(true, "Machine")
                                                              .BuildContributors()
                                                          .NewLogGroup()
                                                          .ForAllLogs()
                                                              .CustomDestination(logDestination1Mock.Object)
                                                              .CustomDestination(logDestination2Mock.Object)
                                                          .BuildLogGroup()
                                                          .BuildLogger();
            // Act
            await logger.LogAsync("context1", LogType.Event, "Description", new { });

            // Assert  
            logDestination1Mock.Verify(x => x.SendAsync(It.Is<LogModel[]>(d => d.Length == 1 &&
                                                                          d[0].LogItems.FirstOrDefault(a => a.Name == "Machine") != null), It.IsAny<CancellationToken>()), Times.Once);
            logDestination2Mock.Verify(x => x.SendAsync(It.Is<LogModel[]>(d => d.Length == 1 &&
                                                                          d[0].LogItems.FirstOrDefault(a => a.Name == "Machine") != null), It.IsAny<CancellationToken>()), Times.Once);
        } 
    }
}
