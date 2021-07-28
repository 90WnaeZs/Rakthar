namespace Raktár
{
    partial class Ujgep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ujgep));
            this.gepnev_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mentes_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.azonosito_txtbox = new System.Windows.Forms.TextBox();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gepnev_txtbox
            // 
            this.gepnev_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gepnev_txtbox.Location = new System.Drawing.Point(150, 34);
            this.gepnev_txtbox.MaxLength = 30;
            this.gepnev_txtbox.Name = "gepnev_txtbox";
            this.gepnev_txtbox.Size = new System.Drawing.Size(183, 23);
            this.gepnev_txtbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(82, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gépnév:";
            // 
            // mentes_Btn
            // 
            this.mentes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mentes_Btn.Location = new System.Drawing.Point(150, 131);
            this.mentes_Btn.Name = "mentes_Btn";
            this.mentes_Btn.Size = new System.Drawing.Size(183, 44);
            this.mentes_Btn.TabIndex = 4;
            this.mentes_Btn.Text = "Mentés";
            this.mentes_Btn.UseVisualStyleBackColor = true;
            this.mentes_Btn.Click += new System.EventHandler(this.mentes_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(37, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Azonosítószám:";
            // 
            // azonosito_txtbox
            // 
            this.azonosito_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.azonosito_txtbox.Location = new System.Drawing.Point(150, 78);
            this.azonosito_txtbox.MaxLength = 30;
            this.azonosito_txtbox.Name = "azonosito_txtbox";
            this.azonosito_txtbox.Size = new System.Drawing.Size(183, 23);
            this.azonosito_txtbox.TabIndex = 5;
            // 
            // reset_Btn
            // 
            this.reset_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.reset_Btn.Location = new System.Drawing.Point(40, 131);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(75, 44);
            this.reset_Btn.TabIndex = 9;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // Ujgep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(376, 235);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.azonosito_txtbox);
            this.Controls.Add(this.mentes_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gepnev_txtbox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ujgep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Új gép";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gepnev_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mentes_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox azonosito_txtbox;
        private System.Windows.Forms.Button reset_Btn;
    }
}