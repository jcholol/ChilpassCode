
namespace Chilpass
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.exitButton = new System.Windows.Forms.Button();
            this.documentationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.howToLabel = new System.Windows.Forms.Label();
            this.newPasswordFileField = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(429, 349);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(103, 27);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // documentationLinkLabel
            // 
            this.documentationLinkLabel.AutoSize = true;
            this.documentationLinkLabel.Location = new System.Drawing.Point(12, 361);
            this.documentationLinkLabel.Name = "documentationLinkLabel";
            this.documentationLinkLabel.Size = new System.Drawing.Size(102, 15);
            this.documentationLinkLabel.TabIndex = 3;
            this.documentationLinkLabel.TabStop = true;
            this.documentationLinkLabel.Text = "Design Document";
            this.documentationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.documentationLinkLabel_LinkClicked);
            // 
            // howToLabel
            // 
            this.howToLabel.AutoSize = true;
            this.howToLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.howToLabel.Location = new System.Drawing.Point(12, 9);
            this.howToLabel.Name = "howToLabel";
            this.howToLabel.Size = new System.Drawing.Size(52, 15);
            this.howToLabel.TabIndex = 4;
            this.howToLabel.Text = "How To:";
            // 
            // newPasswordFileField
            // 
            this.newPasswordFileField.Location = new System.Drawing.Point(12, 47);
            this.newPasswordFileField.Name = "newPasswordFileField";
            this.newPasswordFileField.Size = new System.Drawing.Size(520, 84);
            this.newPasswordFileField.TabIndex = 5;
            this.newPasswordFileField.Text = resources.GetString("newPasswordFileField.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Creating a new password file:";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(544, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPasswordFileField);
            this.Controls.Add(this.howToLabel);
            this.Controls.Add(this.documentationLinkLabel);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(560, 420);
            this.MinimumSize = new System.Drawing.Size(560, 420);
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.LinkLabel documentationLinkLabel;
        private System.Windows.Forms.Label howToLabel;
        private System.Windows.Forms.Label newPasswordFileField;
        private System.Windows.Forms.Label label1;
    }
}