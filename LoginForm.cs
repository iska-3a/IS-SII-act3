using System.Data.OleDb;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            btnEnter.Click += btnEnter_Click;
            btnLoginExit.Click += (s, e) => Application.Exit();
            lnkGoSignUp.LinkClicked += lnkGoSignUp_Clicked;

            inpLoginPass.UseSystemPasswordChar = true;
            AcceptButton = btnEnter;   // Enter key logs in
        }

        private void lnkGoSignUp_Clicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignUpForm().Show();
            Hide();
        }

        private void btnEnter_Click(object? sender, EventArgs e)
        {
            string username = inpLoginUser.Text.Trim();
            string password = inpLoginPass.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedHash, fullName, role;
                bool isActive;
                int userId;

                using (OleDbConnection con = DbConnector.GetConnection())
                {
                    con.Open();

                    using (var cmd = new OleDbCommand(
                        "SELECT userID, PasswordHash, FullName, UserRole, IsActive FROM Users WHERE Username = ?", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            userId = Convert.ToInt32(reader["userID"]);
                            storedHash = reader["PasswordHash"].ToString() ?? "";
                            fullName = reader["FullName"].ToString() ?? "";
                            role = reader["UserRole"].ToString() ?? "User";
                            isActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }

                if (!PasswordSecurity.VerifyPassword(password, storedHash))
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!isActive)
                {
                    MessageBox.Show("Your account is inactive. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CurrentUser.UserId = userId;
                CurrentUser.Username = username;
                CurrentUser.FullName = fullName;
                CurrentUser.Role = role;
                AuditLog.Log("LOGIN", "Signed in");

                var dashboard = new HomeForm();
                dashboard.FormClosed += (s, args) => Application.Exit();
                dashboard.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while signing in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
