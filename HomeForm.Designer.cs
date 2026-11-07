namespace InventoryManagementSystem
{
    partial class HomeForm
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
            lblGreeting = new Label();
            lblAccountInfo = new Label();
            btnSignOut = new Button();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Arial Rounded MT Bold", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.FromArgb(209, 208, 208);
            lblGreeting.Location = new Point(60, 130);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(292, 55);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "WELCOME!";
            // 
            // lblAccountInfo
            // 
            lblAccountInfo.AutoSize = true;
            lblAccountInfo.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblAccountInfo.ForeColor = Color.FromArgb(209, 208, 208);
            lblAccountInfo.Location = new Point(64, 200);
            lblAccountInfo.Name = "lblAccountInfo";
            lblAccountInfo.Size = new Size(60, 17);
            lblAccountInfo.TabIndex = 2;
            lblAccountInfo.Text = "role";
            // 
            // btnSignOut
            // 
            btnSignOut.BackColor = Color.FromArgb(209, 208, 208);
            btnSignOut.FlatAppearance.BorderColor = Color.Black;
            btnSignOut.FlatAppearance.BorderSize = 2;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.FromArgb(0, 0, 0);
            btnSignOut.Location = new Point(64, 272);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(148, 48);
            btnSignOut.TabIndex = 1;
            btnSignOut.Text = "Logout";
            btnSignOut.UseVisualStyleBackColor = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(92, 78, 78);
            ClientSize = new Size(800, 450);
            Controls.Add(lblAccountInfo);
            Controls.Add(btnSignOut);
            Controls.Add(lblGreeting);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGreeting;
        private Label lblAccountInfo;
        private Button btnSignOut;
    }
}
