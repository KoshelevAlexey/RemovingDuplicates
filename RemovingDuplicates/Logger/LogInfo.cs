using System;

namespace RemovingDuplicates.Logger
{
    public enum LogLevel { Info = 1, Warn = 2, Error = 3 };

    public class LogInfo
    {
        public LogInfo() 
        { 
            UserName = Environment.UserName;
            Level = LogLevel.Info;
        }
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public LogLevel Level { get; set; }
    }
}
