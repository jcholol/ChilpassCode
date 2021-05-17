
namespace Chilpass
{
    partial class FileForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.Password = new System.Windows.Forms.ColumnHeader();
            this.RemovePasswordButton = new System.Windows.Forms.Button();
            this.NewPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Password});
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(73, 97);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(404, 253);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 200;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 200;
            // 
            // RemovePasswordButton
            // 
            this.RemovePasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RemovePasswordButton.Location = new System.Drawing.Point(315, 39);
            this.RemovePasswordButton.Name = "RemovePasswordButton";
            this.RemovePasswordButton.Size = new System.Drawing.Size(130, 23);
            this.RemovePasswordButton.TabIndex = 5;
            this.RemovePasswordButton.Text = "Remove Password";
            this.RemovePasswordButton.UseVisualStyleBackColor = true;
            this.RemovePasswordButton.Click += new System.EventHandler(this.RemovePasswordButton_Click);
            // 
            // NewPasswordButton
            // 
            this.NewPasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPasswordButton.Location = new System.Drawing.Point(94, 39);
            this.NewPasswordButton.Name = "NewPasswordButton";
            this.NewPasswordButton.Size = new System.Drawing.Size(147, 23);
            this.NewPasswordButton.TabIndex = 4;
            this.NewPasswordButton.Text = "New Password";
            this.NewPasswordButton.UseVisualStyleBackColor = true;
            this.NewPasswordButton.Click += new System.EventHandler(this.NewPasswordButton_Click);
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 381);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.RemovePasswordButton);
            this.Controls.Add(this.NewPasswordButton);
            this.MaximumSize = new System.Drawing.Size(560, 420);
            this.MinimumSize = new System.Drawing.Size(560, 420);
            this.Name = "FileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password File";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button RemovePasswordButton;
        private System.Windows.Forms.Button NewPasswordButton;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Password;
    }
}