using System;
using System.Collections.Generic;
using System.Threading;

namespace TacitusLogger.Contributors.ThreadInfo
{
    public class ThreadInfoContributor : SynchronousLogContributorBase
    {
        public ThreadInfoContributor(string name = "Thread info")
            : base(name)
        {

        }

        protected override Object GenerateLogItemData()
        {
            var currThread = Thread.CurrentThread;
            return new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("Thread id", currThread.ManagedThreadId.ToString()),
                new KeyValuePair<string, string>("Priority", Enum.GetName(typeof(ThreadPriority), currThread.Priority)),
                new KeyValuePair<string, string>("Is background", (currThread.IsBackground) ? "true" : "false"),
                new KeyValuePair<string, string>("Is thread pool thread", (currThread.IsThreadPoolThread) ? "true" : "false"),
                new KeyValuePair<string, string>("Synchronization context", SynchronizationContext.Current?.ToString())
            };
        }
    }
}
