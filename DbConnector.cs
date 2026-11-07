using System.Data.OleDb;

namespace InventoryManagementSystem
{
    public static class DbConnector
    {
        // Fixed location, independent of build output: Documents\IMS\ims_store.accdb
        public static readonly string DbFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IMS");

        public static readonly string DbPath = Path.Combine(DbFolder, "ims_store.accdb");

        private static readonly string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbPath + ";Persist Security Info=False;";

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }
    }
}
