
namespace Chilpass
{
    partial class NPF1
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.RemovePasswordButton = new System.Windows.Forms.Button();
            this.NewPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            listViewItem3.ToolTipText = "Application";
            listViewItem4.ToolTipText = "Password";
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(199, 261);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(412, 97);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(190, 176);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(158, 29);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // RemovePasswordButton
            // 
            this.RemovePasswordButton.Location = new System.Drawing.Point(456, 92);
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
            this.NewPasswordButton.Location = new System.Drawing.Point(190, 92);
            this.NewPasswordButton.Name = "NewPasswordButton";
            this.NewPasswordButton.Size = new System.Drawing.Size(147, 23);
            this.NewPasswordButton.TabIndex = 4;
            this.NewPasswordButton.Text = "New Password";
            this.NewPasswordButton.UseVisualStyleBackColor = true;
            // 
            // NPF1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.RemovePasswordButton);
            this.Controls.Add(this.NewPasswordButton);
            this.Name = "NPF1";
            this.Text = "NPF1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button RemovePasswordButton;
        private System.Windows.Forms.Button NewPasswordButton;
    }
}