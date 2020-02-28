using System.ComponentModel;

namespace TacitusLogger.Contributors.ThreadInfo
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ExtensionsForLog
    {
        public static Log WithThreadInfo(this LogBuilderBase<Log> self)
        {
            return LogBuilderBaseExtensionsHelper.WithThreadInfo(self);
        }
    }
}
