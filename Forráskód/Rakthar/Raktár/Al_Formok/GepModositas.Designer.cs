
namespace Raktár.Al_Formok
{
    partial class GepModositas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.azonosito_combo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gepnev_combo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mire_azon_txt = new System.Windows.Forms.TextBox();
            this.mire_gepnev_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.azonosito_combo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gepnev_combo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // azonosito_combo
            // 
            this.azonosito_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.azonosito_combo.FormattingEnabled = true;
            this.azonosito_combo.Location = new System.Drawing.Point(130, 81);
            this.azonosito_combo.Name = "azonosito_combo";
            this.azonosito_combo.Size = new System.Drawing.Size(191, 24);
            this.azonosito_combo.TabIndex = 21;
            this.azonosito_combo.SelectedIndexChanged += new System.EventHandler(this.azonosito_combo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Azonosítószám:";
            // 
            // gepnev_combo
            // 
            this.gepnev_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gepnev_combo.FormattingEnabled = true;
            this.gepnev_combo.Location = new System.Drawing.Point(130, 51);
            this.gepnev_combo.Name = "gepnev_combo";
            this.gepnev_combo.Size = new System.Drawing.Size(191, 24);
            this.gepnev_combo.TabIndex = 19;
            this.gepnev_combo.SelectedIndexChanged += new System.EventHandler(this.gepnev_combo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(62, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Gépnév:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.mire_azon_txt);
            this.groupBox2.Controls.Add(this.mire_gepnev_txt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(17, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Azonosítószám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "MIRE";
            // 
            // mire_azon_txt
            // 
            this.mire_azon_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mire_azon_txt.Location = new System.Drawing.Point(130, 102);
            this.mire_azon_txt.MaxLength = 20;
            this.mire_azon_txt.Name = "mire_azon_txt";
            this.mire_azon_txt.Size = new System.Drawing.Size(191, 23);
            this.mire_azon_txt.TabIndex = 14;
            // 
            // mire_gepnev_txt
            // 
            this.mire_gepnev_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mire_gepnev_txt.Location = new System.Drawing.Point(130, 58);
            this.mire_gepnev_txt.MaxLength = 20;
            this.mire_gepnev_txt.Name = "mire_gepnev_txt";
            this.mire_gepnev_txt.Size = new System.Drawing.Size(191, 23);
            this.mire_gepnev_txt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(62, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Gépnév:";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(143, 382);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(191, 49);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Mentés";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // GepModositas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(365, 467);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GepModositas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gép módosítás";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mire_azon_txt;
        private System.Windows.Forms.TextBox mire_gepnev_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox azonosito_combo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gepnev_combo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button save_btn;
    }
}