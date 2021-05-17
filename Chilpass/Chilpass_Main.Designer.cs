
namespace Chilpass
{
    partial class Chilpass_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chilpass_Main));
            this.NewPasswordFileButton = new Chilpass.Buttons.RoundButton();
            this.OpenPasswordFileButton = new Chilpass.Buttons.RoundButton();
            this.GeneratePasswordButton = new Chilpass.Buttons.RoundButton();
            this.HelpButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NewPasswordFileButton
            // 
            this.NewPasswordFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPasswordFileButton.BackColor = System.Drawing.Color.LightBlue;
            this.NewPasswordFileButton.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.NewPasswordFileButton.FlatAppearance.BorderSize = 5;
            this.NewPasswordFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPasswordFileButton.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPasswordFileButton.ForeColor = System.Drawing.Color.White;
            this.NewPasswordFileButton.Location = new System.Drawing.Point(202, 167);
            this.NewPasswordFileButton.Name = "NewPasswordFileButton";
            this.NewPasswordFileButton.Size = new System.Drawing.Size(251, 39);
            this.NewPasswordFileButton.TabIndex = 0;
            this.NewPasswordFileButton.Text = "Create New Password File";
            this.NewPasswordFileButton.UseVisualStyleBackColor = false;
            this.NewPasswordFileButton.Click += new System.EventHandler(this.NewPasswordFileButton_Click);
            // 
            // OpenPasswordFileButton
            // 
            this.OpenPasswordFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenPasswordFileButton.BackColor = System.Drawing.Color.LightBlue;
            this.OpenPasswordFileButton.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.OpenPasswordFileButton.FlatAppearance.BorderSize = 5;
            this.OpenPasswordFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenPasswordFileButton.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenPasswordFileButton.ForeColor = System.Drawing.Color.White;
            this.OpenPasswordFileButton.Location = new System.Drawing.Point(202, 231);
            this.OpenPasswordFileButton.Name = "OpenPasswordFileButton";
            this.OpenPasswordFileButton.Size = new System.Drawing.Size(251, 39);
            this.OpenPasswordFileButton.TabIndex = 1;
            this.OpenPasswordFileButton.Text = "Open Password File";
            this.OpenPasswordFileButton.UseVisualStyleBackColor = false;
            this.OpenPasswordFileButton.Click += new System.EventHandler(this.OpenPasswordFileButton_Click);
            // 
            // GeneratePasswordButton
            // 
            this.GeneratePasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeneratePasswordButton.BackColor = System.Drawing.Color.LightBlue;
            this.GeneratePasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.GeneratePasswordButton.FlatAppearance.BorderSize = 5;
            this.GeneratePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GeneratePasswordButton.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GeneratePasswordButton.ForeColor = System.Drawing.Color.White;
            this.GeneratePasswordButton.Location = new System.Drawing.Point(202, 294);
            this.GeneratePasswordButton.Name = "GeneratePasswordButton";
            this.GeneratePasswordButton.Size = new System.Drawing.Size(251, 39);
            this.GeneratePasswordButton.TabIndex = 2;
            this.GeneratePasswordButton.Text = "Generate Password";
            this.GeneratePasswordButton.UseVisualStyleBackColor = false;
            this.GeneratePasswordButton.Click += new System.EventHandler(this.GeneratePasswordButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HelpButton.Location = new System.Drawing.Point(290, 366);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(75, 23);
            this.HelpButton.TabIndex = 3;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.Location = new System.Drawing.Point(290, 395);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(212, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Chilpass_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(644, 456);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.GeneratePasswordButton);
            this.Controls.Add(this.OpenPasswordFileButton);
            this.Controls.Add(this.NewPasswordFileButton);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(660, 495);
            this.MinimumSize = new System.Drawing.Size(660, 495);
            this.Name = "Chilpass_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChilPass";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Buttons.RoundButton NewPasswordFileButton;
        private Buttons.RoundButton OpenPasswordFileButton;
        private Buttons.RoundButton GeneratePasswordButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}