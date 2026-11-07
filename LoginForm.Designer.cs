namespace InventoryManagementSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlLogin = new Panel();
            lnkGoSignUp = new LinkLabel();
            inpLoginPass = new TextBox();
            inpLoginUser = new TextBox();
            btnEnter = new Button();
            lblLogin4 = new Label();
            lblLogin3 = new Label();
            lblLogin2 = new Label();
            lblLogin1 = new Label();
            lblLogin6 = new Label();
            btnLoginExit = new Button();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(92, 78, 78);
            pnlLogin.Controls.Add(lnkGoSignUp);
            pnlLogin.Controls.Add(inpLoginPass);
            pnlLogin.Controls.Add(inpLoginUser);
            pnlLogin.Controls.Add(btnEnter);
            pnlLogin.Controls.Add(lblLogin4);
            pnlLogin.Controls.Add(lblLogin3);
            pnlLogin.Controls.Add(lblLogin2);
            pnlLogin.Controls.Add(lblLogin1);
            pnlLogin.Location = new Point(56, 90);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(685, 337);
            pnlLogin.TabIndex = 0;
            // 
            // lnkGoSignUp
            // 
            lnkGoSignUp.AutoSize = true;
            lnkGoSignUp.Location = new Point(369, 265);
            lnkGoSignUp.Name = "lnkGoSignUp";
            lnkGoSignUp.LinkColor = Color.FromArgb(209, 208, 208);
            lnkGoSignUp.ActiveLinkColor = Color.FromArgb(152, 134, 134);
            lnkGoSignUp.VisitedLinkColor = Color.FromArgb(209, 208, 208);
            lnkGoSignUp.Size = new Size(49, 15);
            lnkGoSignUp.TabIndex = 8;
            lnkGoSignUp.TabStop = true;
            lnkGoSignUp.Text = "Register";
            // 
            // inpLoginPass
            // 
            inpLoginPass.Location = new Point(313, 143);
            inpLoginPass.Name = "inpLoginPass";
            inpLoginPass.BackColor = Color.FromArgb(209, 208, 208);
            inpLoginPass.ForeColor = Color.FromArgb(0, 0, 0);
            inpLoginPass.BorderStyle = BorderStyle.FixedSingle;
            inpLoginPass.Size = new Size(219, 23);
            inpLoginPass.TabIndex = 7;
            // 
            // inpLoginUser
            // 
            inpLoginUser.Location = new Point(313, 109);
            inpLoginUser.Name = "inpLoginUser";
            inpLoginUser.BackColor = Color.FromArgb(209, 208, 208);
            inpLoginUser.ForeColor = Color.FromArgb(0, 0, 0);
            inpLoginUser.BorderStyle = BorderStyle.FixedSingle;
            inpLoginUser.Size = new Size(219, 23);
            inpLoginUser.TabIndex = 6;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.FromArgb(209, 208, 208);
            btnEnter.FlatAppearance.BorderColor = Color.Black;
            btnEnter.FlatAppearance.BorderSize = 2;
            btnEnter.FlatStyle = FlatStyle.Flat;
            btnEnter.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnter.ForeColor = Color.FromArgb(0, 0, 0);
            btnEnter.Location = new Point(277, 204);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(132, 39);
            btnEnter.TabIndex = 5;
            btnEnter.Text = "Login";
            btnEnter.UseVisualStyleBackColor = false;
            // 
            // lblLogin4
            // 
            lblLogin4.AutoSize = true;
            lblLogin4.Location = new Point(232, 265);
            lblLogin4.Name = "lblLogin4";
            lblLogin4.ForeColor = Color.FromArgb(209, 208, 208);
            lblLogin4.Size = new Size(131, 15);
            lblLogin4.TabIndex = 3;
            lblLogin4.Text = "Don't have an account?";
            // 
            // lblLogin3
            // 
            lblLogin3.AutoSize = true;
            lblLogin3.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblLogin3.Location = new Point(175, 145);
            lblLogin3.Name = "lblLogin3";
            lblLogin3.ForeColor = Color.FromArgb(209, 208, 208);
            lblLogin3.Size = new Size(72, 16);
            lblLogin3.TabIndex = 2;
            lblLogin3.Text = "Password:";
            // 
            // lblLogin2
            // 
            lblLogin2.AutoSize = true;
            lblLogin2.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblLogin2.Location = new Point(175, 111);
            lblLogin2.Name = "lblLogin2";
            lblLogin2.ForeColor = Color.FromArgb(209, 208, 208);
            lblLogin2.Size = new Size(75, 16);
            lblLogin2.TabIndex = 1;
            lblLogin2.Text = "Username:";
            // 
            // lblLogin1
            // 
            lblLogin1.AutoSize = true;
            lblLogin1.BackColor = Color.FromArgb(92, 78, 78);
            lblLogin1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin1.ForeColor = Color.FromArgb(209, 208, 208);
            lblLogin1.Location = new Point(219, 35);
            lblLogin1.Name = "lblLogin1";
            lblLogin1.Size = new Size(246, 24);
            lblLogin1.TabIndex = 0;
            lblLogin1.Text = "Sign in to your Account";
            // 
            // lblLogin6
            // 
            lblLogin6.AutoSize = true;
            lblLogin6.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin6.ForeColor = Color.FromArgb(0, 0, 0);
            lblLogin6.Location = new Point(194, 45);
            lblLogin6.Name = "lblLogin6";
            lblLogin6.Size = new Size(419, 32);
            lblLogin6.TabIndex = 1;
            lblLogin6.Text = "Inventory Management System";
            // 
            // btnLoginExit
            // 
            btnLoginExit.BackColor = Color.FromArgb(0, 0, 0);
            btnLoginExit.FlatAppearance.BorderColor = Color.Black;
            btnLoginExit.FlatStyle = FlatStyle.Flat;
            btnLoginExit.ForeColor = Color.FromArgb(209, 208, 208);
            btnLoginExit.Location = new Point(748, 12);
            btnLoginExit.Name = "btnLoginExit";
            btnLoginExit.Size = new Size(40, 29);
            btnLoginExit.TabIndex = 2;
            btnLoginExit.Text = "x";
            btnLoginExit.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(209, 208, 208);
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoginExit);
            Controls.Add(lblLogin6);
            Controls.Add(pnlLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign In";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlLogin;
        private TextBox inpLoginUser;
        private TextBox inpLoginPass;
        private Button btnEnter;
        private Label lblLogin4;
        private Label lblLogin3;
        private Label lblLogin2;
        private Label lblLogin1;
        private Label lblLogin6;
        private Button btnLoginExit;
        private LinkLabel lnkGoSignUp;
    }
}
