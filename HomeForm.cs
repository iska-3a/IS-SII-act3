namespace InventoryManagementSystem
{
    public partial class HomeForm : Form
    {
        private bool loggingOut;

        public HomeForm()
        {
            InitializeComponent();

            lblGreeting.Text = $"WELCOME, {CurrentUser.FullName.ToUpper()}!";
            lblAccountInfo.Text = $"Signed in as {CurrentUser.Username} ({CurrentUser.Role})";

            btnSignOut.Click += btnSignOut_Click;
            FormClosed += (s, e) => { if (!loggingOut) Application.Exit(); };
        }

        private void btnSignOut_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            AuditLog.Log("LOGOUT", "Signed out");
            CurrentUser.Clear();

            loggingOut = true;
            new LoginForm().Show();
            Close();
        }
    }
}
