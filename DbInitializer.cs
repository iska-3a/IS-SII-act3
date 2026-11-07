#nullable disable
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Creates ims_store.accdb and its tables if they do not exist yet.
    /// Same schema as the original project (Users, Products, StockTransactions, ActivityLogs).
    /// </summary>
    public static class DbInitializer
    {
        public static void EnsureCreated()
        {
            Directory.CreateDirectory(DbConnector.DbFolder);

            if (!File.Exists(DbConnector.DbPath))
                CreateEmptyAccdb();

            using (OleDbConnection con = DbConnector.GetConnection())
            {
                con.Open();

                var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                using (DataTable dt = con.GetSchema("Tables"))
                {
                    foreach (DataRow r in dt.Rows)
                        if (r["TABLE_TYPE"].ToString() == "TABLE")
                            existing.Add(r["TABLE_NAME"].ToString());
                }

                if (!existing.Contains("Users"))
                {
                    Run(con, @"CREATE TABLE Users (
                                userID AUTOINCREMENT PRIMARY KEY,
                                Username TEXT(50) NOT NULL,
                                PasswordHash TEXT(255) NOT NULL,
                                FullName TEXT(100),
                                UserRole TEXT(20),
                                IsActive YESNO)");
                    Run(con, "CREATE UNIQUE INDEX idxUsername ON Users (Username)");
                }

                if (!existing.Contains("Products"))
                {
                    Run(con, @"CREATE TABLE Products (
                                ProductID AUTOINCREMENT PRIMARY KEY,
                                ProductName TEXT(100) NOT NULL,
                                [Category] TEXT(50),
                                [Description] TEXT(255),
                                UnitPrice CURRENCY,
                                Quantity LONG,
                                ReorderLevel LONG,
                                CreatedAt DATETIME)");
                }

                if (!existing.Contains("StockTransactions"))
                {
                    Run(con, @"CREATE TABLE StockTransactions (
                                TransactionID AUTOINCREMENT PRIMARY KEY,
                                ProductID LONG,
                                TransactionType TEXT(10),
                                Quantity LONG,
                                TransactionDate DATETIME,
                                ReferenceNote TEXT(255),
                                CreatedBy TEXT(50))");
                }

                if (!existing.Contains("ActivityLogs"))
                {
                    Run(con, @"CREATE TABLE ActivityLogs (
                                LogID AUTOINCREMENT PRIMARY KEY,
                                UserName TEXT(50),
                                ActionName TEXT(100),
                                [Details] TEXT(255),
                                ActionAt DATETIME)");
                }
            }
        }

        private static void Run(OleDbConnection con, string sql)
        {
            using (var cmd = new OleDbCommand(sql, con))
                cmd.ExecuteNonQuery();
        }

        // Uses ADOX (ships with Windows) to create a blank Access 2007+ database.
        private static void CreateEmptyAccdb()
        {
            Type t = Type.GetTypeFromProgID("ADOX.Catalog");
            if (t == null)
                throw new InvalidOperationException(
                    "ADOX is not available. Create an empty Access database named 'ims_store.accdb' in:\n" +
                    DbConnector.DbFolder + "\nThe tables will then be created automatically.");

            dynamic catalog = Activator.CreateInstance(t);
            try
            {
                catalog.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbConnector.DbPath + ";");
            }
            finally
            {
                Marshal.ReleaseComObject(catalog);
            }
        }
    }
}
