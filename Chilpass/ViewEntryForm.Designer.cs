
namespace Chilpass
{
    partial class ViewEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewEntryForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCopyTitle = new System.Windows.Forms.Button();
            this.buttonCopyPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(32, 15);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 110);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 36);
            this.textBoxTitle.Multiline = true;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(446, 71);
            this.textBoxTitle.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 128);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(446, 74);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonCopyTitle
            // 
            this.buttonCopyTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCopyTitle.BackgroundImage")));
            this.buttonCopyTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyTitle.Location = new System.Drawing.Point(464, 57);
            this.buttonCopyTitle.Name = "buttonCopyTitle";
            this.buttonCopyTitle.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyTitle.TabIndex = 4;
            this.buttonCopyTitle.UseVisualStyleBackColor = true;
            this.buttonCopyTitle.Click += new System.EventHandler(this.buttonCopyTitle_Click);
            // 
            // buttonCopyPassword
            // 
            this.buttonCopyPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCopyPassword.BackgroundImage")));
            this.buttonCopyPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyPassword.Location = new System.Drawing.Point(464, 152);
            this.buttonCopyPassword.Name = "buttonCopyPassword";
            this.buttonCopyPassword.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyPassword.TabIndex = 5;
            this.buttonCopyPassword.UseVisualStyleBackColor = true;
            this.buttonCopyPassword.Click += new System.EventHandler(this.buttonCopyPassword_Click);
            // 
            // ViewEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 214);
            this.Controls.Add(this.buttonCopyPassword);
            this.Controls.Add(this.buttonCopyTitle);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(519, 253);
            this.MinimumSize = new System.Drawing.Size(519, 253);
            this.Name = "ViewEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCopyTitle;
        private System.Windows.Forms.Button buttonCopyPassword;
    }
}