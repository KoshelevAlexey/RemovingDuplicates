using System;
using System.Data.SQLite;

namespace RemovingDuplicates.Logger
{
    public class SQLiteDBLogService : ILogService
    {
        private string _connStr = Properties.Settings.Default.ConnectionStr;
        public void WriteLog(LogInfo info)
        {
            using (SQLiteConnection cn = new SQLiteConnection(_connStr))
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Logs(UserName, LogDateTime, FileName, Description, LevelId) VALUES (@name, @dTime, @fileName, @descr, @levelId)", cn);
                cmd.Parameters.AddWithValue("@name", info.UserName);
                cmd.Parameters.AddWithValue("@dTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@fileName", info.FileName);
                cmd.Parameters.AddWithValue("@descr", info.Description);
                cmd.Parameters.AddWithValue("@levelId", info.Level);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
