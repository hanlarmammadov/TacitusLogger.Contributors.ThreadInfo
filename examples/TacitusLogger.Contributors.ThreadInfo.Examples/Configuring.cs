
namespace TacitusLogger.Contributors.ThreadInfo.Examples
{
    class Configuring
    {
        public void Adding_Thread_Info_Contributor_To_The_Logger()
        {
            ThreadInfoContributor threadInfo = new ThreadInfoContributor();

            Logger logger = new Logger();
            logger.AddLogContributor(threadInfo);
        }
        public void Explicitly_Specifying_Name_And_Status_Of_Thread_Info_Contributor()
        {
            ThreadInfoContributor threadInfo = new ThreadInfoContributor("Thread");
            threadInfo.SetActive(true);

            Logger logger = new Logger();
            logger.AddLogContributor(threadInfo);
        }
        public void Explicitly_Specifying_Mutable_Status_Of_Thread_Info_Contributor()
        {
            MutableSetting<bool> status = Setting<bool>.From.Variable(true);
            ThreadInfoContributor threadInfo = new ThreadInfoContributor("Thread");
            threadInfo.SetActive(status);

            Logger logger = new Logger();
            logger.AddLogContributor(threadInfo);
        }
    }
}
