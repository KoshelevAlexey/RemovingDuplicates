
namespace RemovingDuplicates.Logger
{
    public class DBLogger : ILogger
    {
        private ILogService _dbService;

        public DBLogger(ILogService logService) 
        {
            _dbService = logService;
        }

        public void Info(LogInfo info)
        {
            info.Level = LogLevel.Info;
            _dbService.WriteLog(info);
        }

        public void Warn(LogInfo info)
        {
            info.Level = LogLevel.Warn;
            _dbService.WriteLog(info);
        }

        public void Error(LogInfo info)
        {
            info.Level = LogLevel.Error;
            _dbService.WriteLog(info);
        }
    }
}
