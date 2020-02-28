using TacitusLogger.Builders;

namespace TacitusLogger.Contributors.ThreadInfo.Examples
{
    class ConfiguringWithBuilders
    {
        public void Adding_Thread_Info_Contributor_To_The_Logger()
        {
            Logger logger = LoggerBuilder.Logger()
                                         .Contributors()
                                             .ThreadInfo()
                                         .BuildContributors()
                                         .ForAllLogs()
                                             .Console().Add()
                                         .BuildLogger();
        }
        public void Explicitly_Specifying_Name_And_Status_Of_Thread_Info_Contributor()
        {
            Logger logger = LoggerBuilder.Logger()
                                         .Contributors()
                                             .ThreadInfo(true, "Thread")
                                         .BuildContributors()
                                         .ForAllLogs()
                                             .Console().Add()
                                         .BuildLogger();
        }
        public void Explicitly_Specifying_Mutable_Status_Of_Thread_Info_Contributor()
        {
            MutableSetting<bool> status = Setting<bool>.From.Variable(true);

            Logger logger = LoggerBuilder.Logger()
                                         .Contributors()
                                             .ThreadInfo(status)
                                         .BuildContributors()
                                         .ForAllLogs()
                                             .Console().Add()
                                         .BuildLogger();
        }
    }
}
