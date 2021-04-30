namespace AtumZip
{
    partial class SettingsDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDlg));
            this.clbAssociations = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.btnSaveAssoc = new System.Windows.Forms.Button();
            this.btnResetKeys = new System.Windows.Forms.Button();
            this.btnResetAssoc = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbAssociations
            // 
            this.clbAssociations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.clbAssociations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbAssociations.CheckOnClick = true;
            this.clbAssociations.ForeColor = System.Drawing.Color.Gainsboro;
            this.clbAssociations.FormattingEnabled = true;
            this.clbAssociations.Items.AddRange(new object[] {
            ".inf",
            ".obj",
            ".tex",
            ".dat",
            ".map",
            ".sky",
            ".cld"});
            this.clbAssociations.Location = new System.Drawing.Point(6, 19);
            this.clbAssociations.Name = "clbAssociations";
            this.clbAssociations.Size = new System.Drawing.Size(280, 120);
            this.clbAssociations.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAll);
            this.groupBox1.Controls.Add(this.btnSaveAssoc);
            this.groupBox1.Controls.Add(this.clbAssociations);
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Associations";
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(6, 153);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(71, 17);
            this.cbAll.TabIndex = 2;
            this.cbAll.Text = "Check All";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSaveAssoc
            // 
            this.btnSaveAssoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnSaveAssoc.FlatAppearance.BorderSize = 0;
            this.btnSaveAssoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAssoc.Location = new System.Drawing.Point(211, 149);
            this.btnSaveAssoc.Name = "btnSaveAssoc";
            this.btnSaveAssoc.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAssoc.TabIndex = 1;
            this.btnSaveAssoc.Text = "Save";
            this.btnSaveAssoc.UseVisualStyleBackColor = false;
            this.btnSaveAssoc.Click += new System.EventHandler(this.btnSaveAssoc_Click);
            // 
            // btnResetKeys
            // 
            this.btnResetKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnResetKeys.FlatAppearance.BorderSize = 0;
            this.btnResetKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetKeys.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnResetKeys.Location = new System.Drawing.Point(12, 198);
            this.btnResetKeys.Name = "btnResetKeys";
            this.btnResetKeys.Size = new System.Drawing.Size(130, 23);
            this.btnResetKeys.TabIndex = 2;
            this.btnResetKeys.Text = "Reset Xor Keys";
            this.btnResetKeys.UseVisualStyleBackColor = false;
            this.btnResetKeys.Click += new System.EventHandler(this.btnResetKeys_Click);
            // 
            // btnResetAssoc
            // 
            this.btnResetAssoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnResetAssoc.FlatAppearance.BorderSize = 0;
            this.btnResetAssoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetAssoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnResetAssoc.Location = new System.Drawing.Point(174, 198);
            this.btnResetAssoc.Name = "btnResetAssoc";
            this.btnResetAssoc.Size = new System.Drawing.Size(130, 23);
            this.btnResetAssoc.TabIndex = 3;
            this.btnResetAssoc.Text = "Reset Associations";
            this.btnResetAssoc.UseVisualStyleBackColor = false;
            this.btnResetAssoc.Click += new System.EventHandler(this.btnResetAssoc_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdmin.Image = global::AtumZip.Properties.Resources.Admin;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(175, 242);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(130, 23);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Restart as Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(317, 277);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnResetAssoc);
            this.Controls.Add(this.btnResetKeys);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbAssociations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveAssoc;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.Button btnResetKeys;
        private System.Windows.Forms.Button btnResetAssoc;
        private System.Windows.Forms.Button btnAdmin;
    }
}