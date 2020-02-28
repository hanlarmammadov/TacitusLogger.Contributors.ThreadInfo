using Moq;
using NUnit.Framework;

namespace TacitusLogger.Contributors.ThreadInfo.UnitTests
{
    [TestFixture]
    public class ExtensionsForLogTests
    { 
        [Test]
        public void WithThreadInfo_Taking_LogBuilderBase_When_Called_Calls_LogBuilderBase_With_Method_And_Returns_Its_Result()
        {
            // Arrange
            Log log = new Log();
            var logBuilderBaseMock = new Mock<LogBuilderBase<Log>>();
            logBuilderBaseMock.Setup(x => x.With(It.IsAny<LogItem>())).Returns(log);

            // Act
            var returnedLog = ExtensionsForLog.WithThreadInfo(logBuilderBaseMock.Object);

            // Assert  
            logBuilderBaseMock.Verify(x => x.With(It.Is<LogItem>(i => i.Name == "Thread info" && i.Value != null)), Times.Once);
            Assert.AreEqual(log, returnedLog);
        }
    }
}
