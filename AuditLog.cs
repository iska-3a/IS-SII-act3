using System.Data.OleDb;

namespace InventoryManagementSystem
{
    public static class AuditLog
    {
        public static void Log(string action, string details = "")
        {
            try
            {
                using (OleDbConnection con = DbConnector.GetConnection())
                {
                    con.Open();
                    using (var cmd = new OleDbCommand(
                        "INSERT INTO ActivityLogs (UserName, ActionName, [Details], ActionAt) VALUES (?, ?, ?, ?)", con))
                    {
                        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarWChar, 50) { Value = CurrentUser.Username });
                        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarWChar, 100) { Value = action });
                        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarWChar, 255) { Value = details });
                        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.Date) { Value = DateTime.Now });
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // logging must never break the app
            }
        }
    }
}
