namespace Raktár
{
    partial class Utemezes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utemezes));
            this.mentes_Btn = new System.Windows.Forms.Button();
            this.datum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ora = new System.Windows.Forms.DateTimePicker();
            this.azonosito_combo = new System.Windows.Forms.ComboBox();
            this.gepnev_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mentes_Btn
            // 
            this.mentes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mentes_Btn.Location = new System.Drawing.Point(96, 231);
            this.mentes_Btn.Name = "mentes_Btn";
            this.mentes_Btn.Size = new System.Drawing.Size(200, 55);
            this.mentes_Btn.TabIndex = 0;
            this.mentes_Btn.Text = "Mentés";
            this.mentes_Btn.UseVisualStyleBackColor = true;
            this.mentes_Btn.Click += new System.EventHandler(this.mentes_Btn_Click);
            // 
            // datum
            // 
            this.datum.CustomFormat = "yyyy-MM-dd";
            this.datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.datum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum.Location = new System.Drawing.Point(96, 125);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(200, 23);
            this.datum.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gépnév:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(54, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Óra:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(37, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dátum:";
            // 
            // ora
            // 
            this.ora.CustomFormat = "HH:mm";
            this.ora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ora.Location = new System.Drawing.Point(96, 170);
            this.ora.Name = "ora";
            this.ora.ShowUpDown = true;
            this.ora.Size = new System.Drawing.Size(200, 23);
            this.ora.TabIndex = 14;
            // 
            // azonosito_combo
            // 
            this.azonosito_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.azonosito_combo.FormattingEnabled = true;
            this.azonosito_combo.Location = new System.Drawing.Point(96, 78);
            this.azonosito_combo.Name = "azonosito_combo";
            this.azonosito_combo.Size = new System.Drawing.Size(200, 24);
            this.azonosito_combo.TabIndex = 19;
            this.azonosito_combo.SelectedIndexChanged += new System.EventHandler(this.azonosito_combo_SelectedIndexChanged);
            // 
            // gepnev_combo
            // 
            this.gepnev_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gepnev_combo.FormattingEnabled = true;
            this.gepnev_combo.Location = new System.Drawing.Point(96, 34);
            this.gepnev_combo.Name = "gepnev_combo";
            this.gepnev_combo.Size = new System.Drawing.Size(200, 24);
            this.gepnev_combo.TabIndex = 18;
            this.gepnev_combo.SelectedIndexChanged += new System.EventHandler(this.gepnev_combo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Azonosító:";
            // 
            // Utemezes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(330, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.azonosito_combo);
            this.Controls.Add(this.gepnev_combo);
            this.Controls.Add(this.ora);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.mentes_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Utemezes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ütemezés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mentes_Btn;
        private System.Windows.Forms.DateTimePicker datum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ora;
        private System.Windows.Forms.ComboBox azonosito_combo;
        private System.Windows.Forms.ComboBox gepnev_combo;
        private System.Windows.Forms.Label label1;
    }
}