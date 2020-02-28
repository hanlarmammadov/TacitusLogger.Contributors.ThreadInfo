using NUnit.Framework;
using System;
using System.Collections.Generic; 
using System.Threading;
using System.Threading.Tasks;

namespace TacitusLogger.Contributors.ThreadInfo.UnitTests
{
    [TestFixture]
    public class ThreadInfoContributorTests
    {
        #region Ctor tests

        [Test]
        public void Ctor_When_Called_Without_Name_Sets_Default()
        {
            //Act
            ThreadInfoContributor threadInfoContributor = new ThreadInfoContributor();

            //Assert
            Assert.AreEqual("Thread info", threadInfoContributor.Name);
            Assert.IsTrue(threadInfoContributor.IsActive);
        }

        [Test]
        public void Ctor_When_Called_With_Custom_Name_Sets_Default()
        {
            //Act
            ThreadInfoContributor threadInfoContributor = new ThreadInfoContributor("Custom name");

            //Assert
            Assert.AreEqual("Custom name", threadInfoContributor.Name);
            Assert.IsTrue(threadInfoContributor.IsActive);
        }

        #endregion

        #region Tests for ProduceLogItem method

        [Test]
        public void ProduceLogItem_When_Called_Returns_LogItem_With_Data_In_It()
        {
            //Arrange
            ThreadInfoContributor threadInfoContributor = new ThreadInfoContributor();

            //Act
            LogItem logItem = threadInfoContributor.ProduceLogItem();

            //Assert
            Assert.NotNull(logItem);
            Assert.AreEqual("Thread info", logItem.Name);
            Assert.IsInstanceOf<KeyValuePair<string, string>[]>(logItem.Value);
            var data = (KeyValuePair<string, string>[])logItem.Value;
            Assert.AreEqual(5, data.Length);
            Assert.AreEqual("Thread id", data[0].Key);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), data[0].Value);
            Assert.AreEqual("Priority", data[1].Key);
            Assert.AreEqual(Enum.GetName(typeof(ThreadPriority), Thread.CurrentThread.Priority), data[1].Value);
            Assert.AreEqual("Is background", data[2].Key);
            Assert.AreEqual((Thread.CurrentThread.IsBackground) ? "true" : "false", data[2].Value);
            Assert.AreEqual("Is thread pool thread", data[3].Key);
            Assert.AreEqual((Thread.CurrentThread.IsThreadPoolThread) ? "true" : "false", data[3].Value);
            Assert.AreEqual("Synchronization context", data[4].Key);
            Assert.AreEqual(SynchronizationContext.Current?.ToString(), data[4].Value);
        }

        #endregion

        #region Tests for ProduceLogItemAsync method

        [Test]
        public async Task ProduceLogItemAsync_When_Called_Asynchronously_Returns_Log_Item_With_Data_In_It()
        {
            //Arrange
            ThreadInfoContributor threadInfoContributor = new ThreadInfoContributor();

            //Act
            LogItem logItem = await threadInfoContributor.ProduceLogItemAsync();

            //Assert 
            Assert.NotNull(logItem);
            Assert.AreEqual("Thread info", logItem.Name);
            Assert.IsInstanceOf<KeyValuePair<string, string>[]>(logItem.Value);
            var data = (KeyValuePair<string, string>[])logItem.Value;
            Assert.AreEqual(5, data.Length);
            Assert.AreEqual("Thread id", data[0].Key);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), data[0].Value);
            Assert.AreEqual("Priority", data[1].Key);
            Assert.AreEqual(Enum.GetName(typeof(ThreadPriority), Thread.CurrentThread.Priority), data[1].Value);
            Assert.AreEqual("Is background", data[2].Key);
            Assert.AreEqual((Thread.CurrentThread.IsBackground) ? "true" : "false", data[2].Value);
            Assert.AreEqual("Is thread pool thread", data[3].Key);
            Assert.AreEqual((Thread.CurrentThread.IsThreadPoolThread) ? "true" : "false", data[3].Value);
            Assert.AreEqual("Synchronization context", data[4].Key);
            Assert.AreEqual(SynchronizationContext.Current?.ToString(), data[4].Value);
        }
        [Test]
        public void ProduceLogItemAsync_When_Called_With_Cancelled_Token_Returns_Cancelled_Task()
        {
            //Arrange
            ThreadInfoContributor threadInfoContributor = new ThreadInfoContributor();
            CancellationToken cancellationToken = new CancellationToken(canceled: true);

            //Act
            var resultTask = threadInfoContributor.ProduceLogItemAsync(cancellationToken);

            //Assert
            Assert.NotNull(resultTask);
            Assert.IsTrue(resultTask.IsCanceled);
        }

        #endregion
    }
}
