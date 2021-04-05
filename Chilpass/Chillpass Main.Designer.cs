
namespace Chilpass
{
    partial class MAIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GPbutton = new System.Windows.Forms.Button();
            this.HELPbutton = new System.Windows.Forms.Button();
            this.NPFbutton = new System.Windows.Forms.Button();
            this.OPFbutton = new System.Windows.Forms.Button();
            this.EXITbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GPbutton
            // 
            this.GPbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GPbutton.Location = new System.Drawing.Point(339, 283);
            this.GPbutton.Name = "GPbutton";
            this.GPbutton.Size = new System.Drawing.Size(153, 80);
            this.GPbutton.TabIndex = 2;
            this.GPbutton.Text = "Generate Password";
            this.GPbutton.UseVisualStyleBackColor = true;
            this.GPbutton.Click += new System.EventHandler(this.GPbutton_Click);
            // 
            // HELPbutton
            // 
            this.HELPbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HELPbutton.Location = new System.Drawing.Point(381, 400);
            this.HELPbutton.Name = "HELPbutton";
            this.HELPbutton.Size = new System.Drawing.Size(75, 23);
            this.HELPbutton.TabIndex = 3;
            this.HELPbutton.Text = "Help";
            this.HELPbutton.UseVisualStyleBackColor = true;
            this.HELPbutton.Click += new System.EventHandler(this.HELPbutton_Click);
            // 
            // NPFbutton
            // 
            this.NPFbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NPFbutton.Location = new System.Drawing.Point(339, 77);
            this.NPFbutton.Name = "NPFbutton";
            this.NPFbutton.Size = new System.Drawing.Size(153, 80);
            this.NPFbutton.TabIndex = 5;
            this.NPFbutton.Text = "New Password File";
            this.NPFbutton.UseVisualStyleBackColor = true;
            this.NPFbutton.Click += new System.EventHandler(this.NPFbutton_Click);
            // 
            // OPFbutton
            // 
            this.OPFbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OPFbutton.Location = new System.Drawing.Point(339, 182);
            this.OPFbutton.Name = "OPFbutton";
            this.OPFbutton.Size = new System.Drawing.Size(153, 80);
            this.OPFbutton.TabIndex = 6;
            this.OPFbutton.Text = "Open Password File";
            this.OPFbutton.UseVisualStyleBackColor = true;
            this.OPFbutton.Click += new System.EventHandler(this.OPFbutton_Click);
            // 
            // EXITbutton
            // 
            this.EXITbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EXITbutton.Location = new System.Drawing.Point(381, 429);
            this.EXITbutton.Name = "EXITbutton";
            this.EXITbutton.Size = new System.Drawing.Size(75, 23);
            this.EXITbutton.TabIndex = 7;
            this.EXITbutton.Text = "Exit";
            this.EXITbutton.UseVisualStyleBackColor = true;
            this.EXITbutton.Click += new System.EventHandler(this.EXITbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 561);
            this.Controls.Add(this.EXITbutton);
            this.Controls.Add(this.OPFbutton);
            this.Controls.Add(this.NPFbutton);
            this.Controls.Add(this.HELPbutton);
            this.Controls.Add(this.GPbutton);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Chilpass";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GPbutton;
        private System.Windows.Forms.Button HELPbutton;
        private System.Windows.Forms.Button NPFbutton;
        private System.Windows.Forms.Button OPFbutton;
        private System.Windows.Forms.Button EXITbutton;
    }
}

