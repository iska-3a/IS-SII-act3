namespace InventoryManagementSystem
{
    internal static class AppStart
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                DbInitializer.EnsureCreated();   // creates the .accdb + tables on first run
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open or create the database:\n\n" + ex.Message +
                    "\n\nMake sure the Microsoft Access Database Engine (64-bit, ACE OLEDB 12.0) is installed.",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new SignUpForm());
        }
    }
}
