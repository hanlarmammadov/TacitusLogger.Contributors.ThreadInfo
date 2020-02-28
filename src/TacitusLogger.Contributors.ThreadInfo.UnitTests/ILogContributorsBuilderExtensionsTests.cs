using Moq;
using NUnit.Framework;
using TacitusLogger.Builders;

namespace TacitusLogger.Contributors.ThreadInfo.UnitTests
{
    [TestFixture]
    public class ILogContributorsBuilderExtensionsTests
    { 
        [Test]
        public void ThreadInfo_When_Called_Calls_Custom_Method_Of_ILogContributorsBuilder()
        {
            // Arrange
            var logContributorsBuilderMock = new Mock<ILogContributorsBuilder>();
            Setting<bool> isActive = new Mock<Setting<bool>>().Object;

            // Act
            ILogContributorsBuilderExtensions.ThreadInfo(logContributorsBuilderMock.Object, isActive, "custom name");

            // Assert
            logContributorsBuilderMock.Verify(x => x.Custom(It.Is<ThreadInfoContributor>(c => c.Name == "custom name"), isActive), Times.Once);
        }
        [Test]
        public void ThreadInfo_When_Called_Without_Params_Calls_Custom_Method_Of_ILogContributorsBuilder_With_Defaults()
        {
            // Arrange
            var logContributorsBuilderMock = new Mock<ILogContributorsBuilder>();

            // Act
            ILogContributorsBuilderExtensions.ThreadInfo(logContributorsBuilderMock.Object);

            // Assert
            logContributorsBuilderMock.Verify(x => x.Custom(It.Is<ThreadInfoContributor>(c => c.Name == "Thread info"), It.Is<Setting<bool>>(v => v.Value == true)), Times.Once);
        }
        [Test]
        public void ThreadInfo_When_Called_Returns_Result_Of_Custom_Method_Of_ILogContributorsBuilder()
        {
            // Arrange
            var logContributorsBuilderMock = new Mock<ILogContributorsBuilder>();
            logContributorsBuilderMock.Setup(x => x.Custom(It.IsAny<LogContributorBase>(), It.IsAny<Setting<bool>>())).Returns(logContributorsBuilderMock.Object);

            // Act
            ILogContributorsBuilder logContributorsBuilderReturned = ILogContributorsBuilderExtensions.ThreadInfo(logContributorsBuilderMock.Object);

            // Assert
            Assert.AreEqual(logContributorsBuilderMock.Object, logContributorsBuilderReturned);
        }
    }
}
