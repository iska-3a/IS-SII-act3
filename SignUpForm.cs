using System.Data.OleDb;

namespace InventoryManagementSystem
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();

            btnCreateAccount.Click += btnCreateAccount_Click;
            btnSignUpExit.Click += (s, e) => Application.Exit();
            lnkGoLogin.LinkClicked += lnkGoLogin_Clicked;

            inpSignUpPass.UseSystemPasswordChar = true;
            inpSignUpConfirm.UseSystemPasswordChar = true;
            AcceptButton = btnCreateAccount;
        }

        private void lnkGoLogin_Clicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            new LoginForm().Show();
            Hide();
        }

        private void btnCreateAccount_Click(object? sender, EventArgs e)
        {
            string fullName = inpSignUpName.Text.Trim();
            string username = inpSignUpUser.Text.Trim();
            string password = inpSignUpPass.Text;
            string confirmPassword = inpSignUpConfirm.Text;

            if (fullName == "" || username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection con = DbConnector.GetConnection())
                {
                    con.Open();

                    using (var checkCmd = new OleDbCommand("SELECT COUNT(*) FROM Users WHERE Username = ?", con))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // The very first account becomes the administrator.
                    int existingUsers;
                    using (var countCmd = new OleDbCommand("SELECT COUNT(*) FROM Users", con))
                        existingUsers = Convert.ToInt32(countCmd.ExecuteScalar());
                    string role = existingUsers == 0 ? "Admin" : "User";

                    using (var cmd = new OleDbCommand(
                        "INSERT INTO Users (Username, PasswordHash, FullName, UserRole, IsActive) VALUES (?, ?, ?, ?, ?)", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", PasswordSecurity.HashPassword(password));
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@UserRole", role);
                        cmd.Parameters.AddWithValue("@IsActive", true);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show(role == "Admin"
                                ? "Account created. As the first user, you are the administrator."
                                : "User registered successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            inpSignUpName.Clear();
                            inpSignUpUser.Clear();
                            inpSignUpPass.Clear();
                            inpSignUpConfirm.Clear();

                            new LoginForm().Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to register user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while registering the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
