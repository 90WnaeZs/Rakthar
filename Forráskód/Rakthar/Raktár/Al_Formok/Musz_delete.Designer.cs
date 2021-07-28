namespace Raktár
{
    partial class Musz_delete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Musz_delete));
            this.delete_Btn = new System.Windows.Forms.Button();
            this.azonosito_combo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gepnev_combo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // delete_Btn
            // 
            this.delete_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.delete_Btn.Location = new System.Drawing.Point(133, 99);
            this.delete_Btn.Name = "delete_Btn";
            this.delete_Btn.Size = new System.Drawing.Size(189, 49);
            this.delete_Btn.TabIndex = 3;
            this.delete_Btn.Text = "Törlés";
            this.delete_Btn.UseVisualStyleBackColor = true;
            this.delete_Btn.Click += new System.EventHandler(this.delete_Btn_Click);
            // 
            // azonosito_combo
            // 
            this.azonosito_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.azonosito_combo.FormattingEnabled = true;
            this.azonosito_combo.Location = new System.Drawing.Point(131, 58);
            this.azonosito_combo.Name = "azonosito_combo";
            this.azonosito_combo.Size = new System.Drawing.Size(191, 24);
            this.azonosito_combo.TabIndex = 17;
            this.azonosito_combo.SelectedIndexChanged += new System.EventHandler(this.azonosito_combo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(18, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Azonosítószám:";
            // 
            // gepnev_combo
            // 
            this.gepnev_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gepnev_combo.FormattingEnabled = true;
            this.gepnev_combo.Location = new System.Drawing.Point(131, 28);
            this.gepnev_combo.Name = "gepnev_combo";
            this.gepnev_combo.Size = new System.Drawing.Size(191, 24);
            this.gepnev_combo.TabIndex = 15;
            this.gepnev_combo.SelectedIndexChanged += new System.EventHandler(this.gepnev_combo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(63, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Gépnév:";
            // 
            // Musz_delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(343, 185);
            this.Controls.Add(this.azonosito_combo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gepnev_combo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.delete_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Musz_delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gép törlés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button delete_Btn;
        private System.Windows.Forms.ComboBox azonosito_combo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox gepnev_combo;
        private System.Windows.Forms.Label label14;
    }
}