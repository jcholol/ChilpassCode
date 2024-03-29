﻿
namespace Chilpass
{
    partial class GeneratePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratePasswordForm));
            this.sizeTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBarValueLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.linkLabelPassword = new System.Windows.Forms.LinkLabel();
            this.checkedListBoxPassword = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // sizeTrackBar
            // 
            this.sizeTrackBar.Location = new System.Drawing.Point(12, 135);
            this.sizeTrackBar.Maximum = 64;
            this.sizeTrackBar.Minimum = 1;
            this.sizeTrackBar.Name = "sizeTrackBar";
            this.sizeTrackBar.Size = new System.Drawing.Size(284, 45);
            this.sizeTrackBar.TabIndex = 0;
            this.sizeTrackBar.Value = 1;
            // 
            // trackBarValueLabel
            // 
            this.trackBarValueLabel.AutoSize = true;
            this.trackBarValueLabel.Location = new System.Drawing.Point(12, 174);
            this.trackBarValueLabel.Name = "trackBarValueLabel";
            this.trackBarValueLabel.Size = new System.Drawing.Size(33, 15);
            this.trackBarValueLabel.TabIndex = 1;
            this.trackBarValueLabel.Text = "Size: ";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 90);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(252, 39);
            this.passwordTextBox.TabIndex = 2;
            // 
            // copyButton
            // 
            this.copyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copyButton.BackgroundImage")));
            this.copyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.copyButton.Location = new System.Drawing.Point(270, 90);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(26, 26);
            this.copyButton.TabIndex = 3;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // linkLabelPassword
            // 
            this.linkLabelPassword.AutoSize = true;
            this.linkLabelPassword.Location = new System.Drawing.Point(143, 183);
            this.linkLabelPassword.Name = "linkLabelPassword";
            this.linkLabelPassword.Size = new System.Drawing.Size(159, 15);
            this.linkLabelPassword.TabIndex = 4;
            this.linkLabelPassword.TabStop = true;
            this.linkLabelPassword.Text = "How Secure Is My Password?";
            this.linkLabelPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPassword_LinkClicked);
            // 
            // checkedListBoxPassword
            // 
            this.checkedListBoxPassword.BackColor = System.Drawing.SystemColors.Menu;
            this.checkedListBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxPassword.CheckOnClick = true;
            this.checkedListBoxPassword.FormattingEnabled = true;
            this.checkedListBoxPassword.Items.AddRange(new object[] {
            "Lower Case Latters (a-z)",
            "Upper Case Letters (A-Z)",
            "Digits (0-9)",
            "Special Characters (?!#{})"});
            this.checkedListBoxPassword.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxPassword.Name = "checkedListBoxPassword";
            this.checkedListBoxPassword.Size = new System.Drawing.Size(177, 72);
            this.checkedListBoxPassword.TabIndex = 13;
            // 
            // GeneratePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 214);
            this.Controls.Add(this.checkedListBoxPassword);
            this.Controls.Add(this.linkLabelPassword);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.trackBarValueLabel);
            this.Controls.Add(this.sizeTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GeneratePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Password";
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar sizeTrackBar;
        private System.Windows.Forms.Label trackBarValueLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.LinkLabel linkLabelPassword;
        private System.Windows.Forms.CheckedListBox checkedListBoxPassword;
    }
}