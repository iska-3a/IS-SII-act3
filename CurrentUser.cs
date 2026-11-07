namespace InventoryManagementSystem
{
    /// <summary>The currently signed-in user.</summary>
    public static class CurrentUser
    {
        public static int UserId;
        public static string Username = "";
        public static string FullName = "";
        public static string Role = "User";

        public static bool IsAdmin => string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);

        public static void Clear()
        {
            UserId = 0; Username = ""; FullName = ""; Role = "User";
        }
    }
}
