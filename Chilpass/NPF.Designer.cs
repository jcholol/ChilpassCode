﻿
namespace Chilpass
{
    partial class NPF
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
            this.EnterPasswordBox = new System.Windows.Forms.TextBox();
            this.EnterMasterPasswordBox = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnterPasswordBox
            // 
            this.EnterPasswordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPasswordBox.Location = new System.Drawing.Point(328, 198);
            this.EnterPasswordBox.Name = "EnterPasswordBox";
            this.EnterPasswordBox.PasswordChar = '*';
            this.EnterPasswordBox.Size = new System.Drawing.Size(126, 23);
            this.EnterPasswordBox.TabIndex = 3;
            this.EnterPasswordBox.Text = "Enter Password...";
            // 
            // EnterMasterPasswordBox
            // 
            this.EnterMasterPasswordBox.AutoSize = true;
            this.EnterMasterPasswordBox.Location = new System.Drawing.Point(328, 180);
            this.EnterMasterPasswordBox.Name = "EnterMasterPasswordBox";
            this.EnterMasterPasswordBox.Size = new System.Drawing.Size(126, 15);
            this.EnterMasterPasswordBox.TabIndex = 4;
            this.EnterMasterPasswordBox.Text = "Enter master password";
            this.EnterMasterPasswordBox.Click += new System.EventHandler(this.EnterMasterPasswordBox_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(328, 227);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(54, 22);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(388, 227);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(54, 22);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.EnterMasterPasswordBox);
            this.Controls.Add(this.EnterPasswordBox);
            this.Name = "NPF";
            this.Text = "New Password File";
            this.Load += new System.EventHandler(this.NPF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EnterPasswordBox;
        private System.Windows.Forms.Label EnterMasterPasswordBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button ExitButton;
    }
}