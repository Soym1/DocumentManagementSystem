namespace DocumentManagementSystem
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreat = new System.Windows.Forms.Button();
            this.lbPW = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.lbWrongAccount = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCreat);
            this.panel1.Controls.Add(this.lbPW);
            this.panel1.Controls.Add(this.lbID);
            this.panel1.Controls.Add(this.lbWrongAccount);
            this.panel1.Controls.Add(this.btLogin);
            this.panel1.Controls.Add(this.textBoxPW);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 366);
            this.panel1.TabIndex = 12;
            // 
            // btnCreat
            // 
            this.btnCreat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreat.Location = new System.Drawing.Point(339, 207);
            this.btnCreat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(92, 23);
            this.btnCreat.TabIndex = 11;
            this.btnCreat.Text = "Creat New";
            this.btnCreat.UseVisualStyleBackColor = true;
            this.btnCreat.Click += new System.EventHandler(this.btnCreat_Click);
            // 
            // lbPW
            // 
            this.lbPW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPW.AutoSize = true;
            this.lbPW.Location = new System.Drawing.Point(145, 166);
            this.lbPW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPW.Name = "lbPW";
            this.lbPW.Size = new System.Drawing.Size(53, 13);
            this.lbPW.TabIndex = 10;
            this.lbPW.Text = "Password";
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(145, 126);
            this.lbID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(55, 13);
            this.lbID.TabIndex = 9;
            this.lbID.Text = "Username";
            // 
            // lbWrongAccount
            // 
            this.lbWrongAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbWrongAccount.AutoSize = true;
            this.lbWrongAccount.ForeColor = System.Drawing.Color.Red;
            this.lbWrongAccount.Location = new System.Drawing.Point(213, 242);
            this.lbWrongAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWrongAccount.Name = "lbWrongAccount";
            this.lbWrongAccount.Size = new System.Drawing.Size(210, 13);
            this.lbWrongAccount.TabIndex = 8;
            this.lbWrongAccount.Text = "ID or password is wrong. Try again, please!";
            this.lbWrongAccount.Visible = false;
            // 
            // btLogin
            // 
            this.btLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btLogin.Location = new System.Drawing.Point(148, 207);
            this.btLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(92, 23);
            this.btLogin.TabIndex = 7;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // textBoxPW
            // 
            this.textBoxPW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPW.Location = new System.Drawing.Point(236, 164);
            this.textBoxPW.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.PasswordChar = '*';
            this.textBoxPW.Size = new System.Drawing.Size(160, 20);
            this.textBoxPW.TabIndex = 3;
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxID.Location = new System.Drawing.Point(236, 123);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(160, 20);
            this.textBoxID.TabIndex = 2;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreat;
        private System.Windows.Forms.Label lbPW;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbWrongAccount;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.TextBox textBoxID;
    }
}