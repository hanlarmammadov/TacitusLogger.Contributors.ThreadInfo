
namespace TacitusLogger.Contributors.ThreadInfo
{
    internal static class LogBuilderBaseExtensionsHelper
    {
        public static TReturn WithThreadInfo<TReturn>(LogBuilderBase<TReturn> self)
        {
            return self.With(new LogItem("Thread info", new ThreadInfoContributor().ProduceLogItem()));
        }
    }
}
