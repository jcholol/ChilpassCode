
namespace Chilpass
{
    partial class OPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPF));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterPasswordBox = new System.Windows.Forms.TextBox();
            this.showPasswordButton = new System.Windows.Forms.Button();
            this.showPasswordToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter master password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EnterPasswordBox
            // 
            this.EnterPasswordBox.Location = new System.Drawing.Point(56, 59);
            this.EnterPasswordBox.Name = "EnterPasswordBox";
            this.EnterPasswordBox.PasswordChar = '*';
            this.EnterPasswordBox.Size = new System.Drawing.Size(128, 23);
            this.EnterPasswordBox.TabIndex = 3;
            // 
            // showPasswordButton
            // 
            this.showPasswordButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showPasswordButton.BackgroundImage")));
            this.showPasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showPasswordButton.Location = new System.Drawing.Point(190, 56);
            this.showPasswordButton.Name = "showPasswordButton";
            this.showPasswordButton.Size = new System.Drawing.Size(26, 26);
            this.showPasswordButton.TabIndex = 9;
            this.showPasswordToolTip.SetToolTip(this.showPasswordButton, "Toggle Password Visibility");
            this.showPasswordButton.UseVisualStyleBackColor = true;
            this.showPasswordButton.Click += new System.EventHandler(this.showPasswordButton_Click);
            // 
            // OPF
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 153);
            this.Controls.Add(this.showPasswordButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterPasswordBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(256, 192);
            this.MinimumSize = new System.Drawing.Size(256, 192);
            this.Name = "OPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Password File";
            this.Load += new System.EventHandler(this.OPF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnterPasswordBox;
        private System.Windows.Forms.Button showPasswordButton;
        private System.Windows.Forms.ToolTip showPasswordToolTip;
    }
}