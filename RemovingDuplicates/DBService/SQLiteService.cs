using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace RemovingDuplicates.DBService
{
    public class SQLiteService : IDBService
    {
        private string _connStr = Properties.Settings.Default.ConnectionStr;

        public void CreateDB()
        {
            string name = Properties.Settings.Default.DBName;
            if (File.Exists(name)) 
                return;

            SQLiteConnection.CreateFile(name);
        }

        public void CreateTables()
        {
            using (SQLiteConnection cn = new SQLiteConnection(_connStr))
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS [Logs]([Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL, LevelId int NOT NULL, [UserName] varchar(50) NOT NULL, LogDateTime datetime NOT NULL, FileName varchar(300), Description varchar(300) NOT NULL)", cn);
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand("DROP TABLE IF EXISTS [LogLevels]; CREATE TABLE [LogLevels]([Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL, Level varchar(20) NOT NULL); INSERT INTO LogLevels (Level) VALUES ('Info'), ('Warn'), ('Error')", cn);
                cmd.ExecuteNonQuery();
            }
        }

        public void FillDataTable(DataTable dt)
        {
            using (SQLiteConnection cn = new SQLiteConnection(_connStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter($"SELECT L.Id, V.Level, L.UserName, L.LogDateTime, L.FileName, L.Description FROM Logs as L INNER JOIN LogLevels as V on L.LevelId = V.Id", cn);
                da.Fill(dt);
            }
        }
    }
}
