using System.ComponentModel;
using TacitusLogger.Builders;

namespace TacitusLogger.Contributors.ThreadInfo
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ILogContributorsBuilderExtensions
    {
        public static ILogContributorsBuilder ThreadInfo(this ILogContributorsBuilder self, Setting<bool> isActive, string name = "Thread info")
        {
            return self.Custom(new ThreadInfoContributor(name), isActive);
        }
        public static ILogContributorsBuilder ThreadInfo(this ILogContributorsBuilder self, string name = "Thread info")
        {
            return self.Custom(new ThreadInfoContributor(name), true);
        }
    }
}
