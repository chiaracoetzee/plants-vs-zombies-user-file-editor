namespace Plants_vs.Zombies_user_file_editor
{
    partial class FormSelectUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectUser));
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserDataFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseUserDataFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select a &user to edit:";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(13, 64);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(259, 186);
            this.listBoxUsers.TabIndex = 1;
            this.listBoxUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxUsers_MouseDoubleClick);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 256);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User data &folder:";
            // 
            // textBoxUserDataFolder
            // 
            this.textBoxUserDataFolder.Location = new System.Drawing.Point(15, 25);
            this.textBoxUserDataFolder.Name = "textBoxUserDataFolder";
            this.textBoxUserDataFolder.Size = new System.Drawing.Size(176, 20);
            this.textBoxUserDataFolder.TabIndex = 4;
            this.textBoxUserDataFolder.Leave += new System.EventHandler(this.textBoxUserDataFolder_Leave);
            // 
            // buttonBrowseUserDataFolder
            // 
            this.buttonBrowseUserDataFolder.Location = new System.Drawing.Point(197, 25);
            this.buttonBrowseUserDataFolder.Name = "buttonBrowseUserDataFolder";
            this.buttonBrowseUserDataFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseUserDataFolder.TabIndex = 5;
            this.buttonBrowseUserDataFolder.Text = "&Browse...";
            this.buttonBrowseUserDataFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseUserDataFolder.Click += new System.EventHandler(this.buttonBrowseUserDataFolder_Click);
            // 
            // FormSelectUser
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.buttonBrowseUserDataFolder);
            this.Controls.Add(this.textBoxUserDataFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelectUser";
            this.Text = "Select a user";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserDataFolder;
        private System.Windows.Forms.Button buttonBrowseUserDataFolder;
    }
}