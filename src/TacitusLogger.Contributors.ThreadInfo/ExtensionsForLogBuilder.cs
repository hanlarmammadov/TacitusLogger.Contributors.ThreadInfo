using System.ComponentModel; 

namespace TacitusLogger.Contributors.ThreadInfo
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ExtensionsForLogBuilder
    { 
        public static LogBuilder WithThreadInfo(this LogBuilderBase<LogBuilder> self)
        {
            return LogBuilderBaseExtensionsHelper.WithThreadInfo(self);
        }
    }
}
