using Moq;
using NUnit.Framework;

namespace TacitusLogger.Contributors.ThreadInfo.UnitTests
{
    [TestFixture]
    public class ExtensionsForLogBuilderTests
    {
        [Test]
        public void WithThreadInfo_Taking_LogBuilderBase_When_Called_Calls_LogBuilderBase_With_Method_And_Returns_Its_Result()
        {
            // Arrange
            var logger = new Mock<ILogger>().Object;
            LogBuilder logBuilder = logger.Error("");
            var logBuilderBaseMock = new Mock<LogBuilderBase<LogBuilder>>();
            logBuilderBaseMock.Setup(x => x.With(It.IsAny<LogItem>())).Returns(logBuilder);

            // Act
            var returnedLog = ExtensionsForLogBuilder.WithThreadInfo(logBuilderBaseMock.Object);

            // Assert  
            logBuilderBaseMock.Verify(x => x.With(It.Is<LogItem>(i => i.Name == "Thread info" && i.Value != null)), Times.Once);
            Assert.AreEqual(logBuilder, returnedLog);
        }
    }
}
