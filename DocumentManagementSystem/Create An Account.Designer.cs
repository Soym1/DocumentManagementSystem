namespace DocumentManagementSystem
{
    partial class Create_An_Account
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
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.lbWrongAccount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxConfirm = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUserName.Location = new System.Drawing.Point(119, 60);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(113, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassword.Location = new System.Drawing.Point(119, 84);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(113, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "Gruop 1",
            "Gruop 2",
            "Gruop 3"});
            this.comboBoxGroup.Location = new System.Drawing.Point(119, 156);
            this.comboBoxGroup.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(113, 21);
            this.comboBoxGroup.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Group";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "NickName";
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNickName.Location = new System.Drawing.Point(119, 132);
            this.textBoxNickName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(113, 20);
            this.textBoxNickName.TabIndex = 9;
            // 
            // btCreate
            // 
            this.btCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCreate.Location = new System.Drawing.Point(62, 217);
            this.btCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(56, 19);
            this.btCreate.TabIndex = 11;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // lbWrongAccount
            // 
            this.lbWrongAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbWrongAccount.AutoSize = true;
            this.lbWrongAccount.ForeColor = System.Drawing.Color.Red;
            this.lbWrongAccount.Location = new System.Drawing.Point(17, 276);
            this.lbWrongAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWrongAccount.Name = "lbWrongAccount";
            this.lbWrongAccount.Size = new System.Drawing.Size(270, 13);
            this.lbWrongAccount.TabIndex = 12;
            this.lbWrongAccount.Text = "Nickname is exist or confirm is wrong. Try again, please!";
            this.lbWrongAccount.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Confirm";
            // 
            // txtBoxConfirm
            // 
            this.txtBoxConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxConfirm.Location = new System.Drawing.Point(119, 108);
            this.txtBoxConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxConfirm.Name = "txtBoxConfirm";
            this.txtBoxConfirm.PasswordChar = '*';
            this.txtBoxConfirm.Size = new System.Drawing.Size(113, 20);
            this.txtBoxConfirm.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(176, 217);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Create_An_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 352);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxConfirm);
            this.Controls.Add(this.lbWrongAccount);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNickName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Create_An_Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create_An_Account";
            this.Load += new System.EventHandler(this.Create_An_Account_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNickName;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label lbWrongAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}