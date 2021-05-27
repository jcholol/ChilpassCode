
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPF));
            this.EnterPasswordBox = new System.Windows.Forms.TextBox();
            this.EnterMasterPasswordBox = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.ConfirmationBox = new System.Windows.Forms.TextBox();
            this.ConfirmationLabel = new System.Windows.Forms.Label();
            this.showPasswordButton = new System.Windows.Forms.Button();
            this.showPasswordToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // EnterPasswordBox
            // 
            this.EnterPasswordBox.Location = new System.Drawing.Point(60, 31);
            this.EnterPasswordBox.Name = "EnterPasswordBox";
            this.EnterPasswordBox.PasswordChar = '*';
            this.EnterPasswordBox.Size = new System.Drawing.Size(143, 23);
            this.EnterPasswordBox.TabIndex = 3;
            // 
            // EnterMasterPasswordBox
            // 
            this.EnterMasterPasswordBox.AutoSize = true;
            this.EnterMasterPasswordBox.Location = new System.Drawing.Point(60, 13);
            this.EnterMasterPasswordBox.Name = "EnterMasterPasswordBox";
            this.EnterMasterPasswordBox.Size = new System.Drawing.Size(126, 15);
            this.EnterMasterPasswordBox.TabIndex = 4;
            this.EnterMasterPasswordBox.Text = "Enter master password";
            this.EnterMasterPasswordBox.Click += new System.EventHandler(this.EnterMasterPasswordBox_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(78, 131);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(97, 22);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ConfirmationBox
            // 
            this.ConfirmationBox.Location = new System.Drawing.Point(60, 95);
            this.ConfirmationBox.Name = "ConfirmationBox";
            this.ConfirmationBox.PasswordChar = '*';
            this.ConfirmationBox.Size = new System.Drawing.Size(143, 23);
            this.ConfirmationBox.TabIndex = 6;
            // 
            // ConfirmationLabel
            // 
            this.ConfirmationLabel.AutoSize = true;
            this.ConfirmationLabel.Location = new System.Drawing.Point(60, 77);
            this.ConfirmationLabel.Name = "ConfirmationLabel";
            this.ConfirmationLabel.Size = new System.Drawing.Size(143, 15);
            this.ConfirmationLabel.TabIndex = 7;
            this.ConfirmationLabel.Text = "Confirm master password";
            // 
            // showPasswordButton
            // 
            this.showPasswordButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showPasswordButton.BackgroundImage")));
            this.showPasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showPasswordButton.Location = new System.Drawing.Point(209, 28);
            this.showPasswordButton.Name = "showPasswordButton";
            this.showPasswordButton.Size = new System.Drawing.Size(26, 26);
            this.showPasswordButton.TabIndex = 8;
            this.showPasswordToolTip.SetToolTip(this.showPasswordButton, "Toggle Password Visibility");
            this.showPasswordButton.UseVisualStyleBackColor = true;
            this.showPasswordButton.Click += new System.EventHandler(this.showPasswordButton_Click);
            // 
            // NPF
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 165);
            this.Controls.Add(this.showPasswordButton);
            this.Controls.Add(this.ConfirmationLabel);
            this.Controls.Add(this.ConfirmationBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.EnterMasterPasswordBox);
            this.Controls.Add(this.EnterPasswordBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(272, 204);
            this.MinimumSize = new System.Drawing.Size(272, 204);
            this.Name = "NPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Password File";
            this.Load += new System.EventHandler(this.NPF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EnterPasswordBox;
        private System.Windows.Forms.Label EnterMasterPasswordBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox ConfirmationBox;
        private System.Windows.Forms.Label ConfirmationLabel;
        private System.Windows.Forms.Button showPasswordButton;
        private System.Windows.Forms.ToolTip showPasswordToolTip;
    }
}