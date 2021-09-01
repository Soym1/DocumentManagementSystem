namespace DocumentManagementSystem
{
    partial class ManagementPermissionUsers
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeGroupToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChangeToGroup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopEnableEdittingGroup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopUnableEdittingGroup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChangeToGroup2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopEnableEdittingGroup2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopUnableEdittingGroup2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChangeToGroup3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopEnableEdittingGroup3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toopUnableEdittingGroup3 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(14, 14);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(572, 220);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeGroupToToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // changeGroupToToolStripMenuItem
            // 
            this.changeGroupToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolChangeToGroup1,
            this.toolChangeToGroup2,
            this.toolChangeToGroup3});
            this.changeGroupToToolStripMenuItem.Name = "changeGroupToToolStripMenuItem";
            this.changeGroupToToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.changeGroupToToolStripMenuItem.Text = "Change Group to";
            // 
            // toolChangeToGroup1
            // 
            this.toolChangeToGroup1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toopEnableEdittingGroup1,
            this.toopUnableEdittingGroup1});
            this.toolChangeToGroup1.Name = "toolChangeToGroup1";
            this.toolChangeToGroup1.Size = new System.Drawing.Size(80, 22);
            this.toolChangeToGroup1.Text = "1";
            // 
            // toopEnableEdittingGroup1
            // 
            this.toopEnableEdittingGroup1.Name = "toopEnableEdittingGroup1";
            this.toopEnableEdittingGroup1.Size = new System.Drawing.Size(151, 22);
            this.toopEnableEdittingGroup1.Text = "Enable Editing";
            // 
            // toopUnableEdittingGroup1
            // 
            this.toopUnableEdittingGroup1.Name = "toopUnableEdittingGroup1";
            this.toopUnableEdittingGroup1.Size = new System.Drawing.Size(151, 22);
            this.toopUnableEdittingGroup1.Text = "Unable Editing";
            // 
            // toolChangeToGroup2
            // 
            this.toolChangeToGroup2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toopEnableEdittingGroup2,
            this.toopUnableEdittingGroup2});
            this.toolChangeToGroup2.Name = "toolChangeToGroup2";
            this.toolChangeToGroup2.Size = new System.Drawing.Size(80, 22);
            this.toolChangeToGroup2.Text = "2";
            // 
            // toopEnableEdittingGroup2
            // 
            this.toopEnableEdittingGroup2.Name = "toopEnableEdittingGroup2";
            this.toopEnableEdittingGroup2.Size = new System.Drawing.Size(151, 22);
            this.toopEnableEdittingGroup2.Text = "Enable Editing";
            // 
            // toopUnableEdittingGroup2
            // 
            this.toopUnableEdittingGroup2.Name = "toopUnableEdittingGroup2";
            this.toopUnableEdittingGroup2.Size = new System.Drawing.Size(151, 22);
            this.toopUnableEdittingGroup2.Text = "Unable Editing";
            // 
            // toolChangeToGroup3
            // 
            this.toolChangeToGroup3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toopEnableEdittingGroup3,
            this.toopUnableEdittingGroup3});
            this.toolChangeToGroup3.Name = "toolChangeToGroup3";
            this.toolChangeToGroup3.Size = new System.Drawing.Size(80, 22);
            this.toolChangeToGroup3.Text = "3";
            // 
            // toopEnableEdittingGroup3
            // 
            this.toopEnableEdittingGroup3.Name = "toopEnableEdittingGroup3";
            this.toopEnableEdittingGroup3.Size = new System.Drawing.Size(151, 22);
            this.toopEnableEdittingGroup3.Text = "Enable Editing";
            // 
            // toopUnableEdittingGroup3
            // 
            this.toopUnableEdittingGroup3.Name = "toopUnableEdittingGroup3";
            this.toopUnableEdittingGroup3.Size = new System.Drawing.Size(151, 22);
            this.toopUnableEdittingGroup3.Text = "Unable Editing";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(14, 247);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(466, 98);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManagementPermissionUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManagementPermissionUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagementPermissionUsers";
            this.Load += new System.EventHandler(this.ManagementPermissionUsers_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeGroupToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolChangeToGroup1;
        private System.Windows.Forms.ToolStripMenuItem toolChangeToGroup2;
        private System.Windows.Forms.ToolStripMenuItem toolChangeToGroup3;
        private System.Windows.Forms.ToolStripMenuItem toopEnableEdittingGroup1;
        private System.Windows.Forms.ToolStripMenuItem toopUnableEdittingGroup1;
        private System.Windows.Forms.ToolStripMenuItem toopEnableEdittingGroup2;
        private System.Windows.Forms.ToolStripMenuItem toopEnableEdittingGroup3;
        private System.Windows.Forms.ToolStripMenuItem toopUnableEdittingGroup2;
        private System.Windows.Forms.ToolStripMenuItem toopUnableEdittingGroup3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}