namespace Raktár
{
    partial class Torles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Torles));
            this.torles_Btn = new System.Windows.Forms.Button();
            this.gyartoi_combo = new System.Windows.Forms.ComboBox();
            this.cikknev_combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // torles_Btn
            // 
            this.torles_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.torles_Btn.Location = new System.Drawing.Point(121, 99);
            this.torles_Btn.Name = "torles_Btn";
            this.torles_Btn.Size = new System.Drawing.Size(224, 50);
            this.torles_Btn.TabIndex = 0;
            this.torles_Btn.Text = "Törlés";
            this.torles_Btn.UseVisualStyleBackColor = true;
            this.torles_Btn.Click += new System.EventHandler(this.torles_Btn_Click);
            // 
            // gyartoi_combo
            // 
            this.gyartoi_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gyartoi_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gyartoi_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gyartoi_combo.FormattingEnabled = true;
            this.gyartoi_combo.Location = new System.Drawing.Point(121, 57);
            this.gyartoi_combo.Name = "gyartoi_combo";
            this.gyartoi_combo.Size = new System.Drawing.Size(224, 24);
            this.gyartoi_combo.TabIndex = 67;
            this.gyartoi_combo.SelectedIndexChanged += new System.EventHandler(this.gyartoi_combo_SelectedIndexChanged);
            // 
            // cikknev_combo
            // 
            this.cikknev_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cikknev_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cikknev_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cikknev_combo.FormattingEnabled = true;
            this.cikknev_combo.Location = new System.Drawing.Point(121, 27);
            this.cikknev_combo.Name = "cikknev_combo";
            this.cikknev_combo.Size = new System.Drawing.Size(224, 24);
            this.cikknev_combo.TabIndex = 66;
            this.cikknev_combo.SelectedIndexChanged += new System.EventHandler(this.cikkNev_combo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(54, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 64;
            this.label4.Text = "Cikknév:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(57, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "Gyártói:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(138, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 48);
            this.label1.TabIndex = 68;
            this.label1.Text = "Csak olyan cikket lehet törölni, \r\namiből már nincs raktáron!\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Torles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(420, 256);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gyartoi_combo);
            this.Controls.Add(this.cikknev_combo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.torles_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Torles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Törlés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button torles_Btn;
        private System.Windows.Forms.ComboBox gyartoi_combo;
        private System.Windows.Forms.ComboBox cikknev_combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}