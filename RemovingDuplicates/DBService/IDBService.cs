using System.Data;

namespace RemovingDuplicates.DBService
{
    public interface IDBService
    {
        void CreateDB();
        void CreateTables();
        void FillDataTable(DataTable dt);
    }
}