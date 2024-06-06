
namespace RemovingDuplicates.Logger
{
    public interface ILogger
    {
        void Info(LogInfo info);
        void Warn(LogInfo info);
        void Error(LogInfo info);
    }
}
