
namespace Raktár.Al_Formok
{
    partial class MettolMeddig
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
            this.mettolDateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.mettol_GB = new System.Windows.Forms.GroupBox();
            this.meddig_GB = new System.Windows.Forms.GroupBox();
            this.meddigDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.kereses_Btn = new System.Windows.Forms.Button();
            this.mettol_GB.SuspendLayout();
            this.meddig_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // mettolDateTime
            // 
            this.mettolDateTime.Location = new System.Drawing.Point(10, 42);
            this.mettolDateTime.Name = "mettolDateTime";
            this.mettolDateTime.Size = new System.Drawing.Size(200, 20);
            this.mettolDateTime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mettől";
            // 
            // mettol_GB
            // 
            this.mettol_GB.Controls.Add(this.mettolDateTime);
            this.mettol_GB.Controls.Add(this.label1);
            this.mettol_GB.Location = new System.Drawing.Point(37, 29);
            this.mettol_GB.Name = "mettol_GB";
            this.mettol_GB.Size = new System.Drawing.Size(231, 148);
            this.mettol_GB.TabIndex = 4;
            this.mettol_GB.TabStop = false;
            // 
            // meddig_GB
            // 
            this.meddig_GB.Controls.Add(this.meddigDateTime);
            this.meddig_GB.Controls.Add(this.label2);
            this.meddig_GB.Location = new System.Drawing.Point(294, 29);
            this.meddig_GB.Name = "meddig_GB";
            this.meddig_GB.Size = new System.Drawing.Size(231, 148);
            this.meddig_GB.TabIndex = 5;
            this.meddig_GB.TabStop = false;
            // 
            // meddigDateTime
            // 
            this.meddigDateTime.Location = new System.Drawing.Point(10, 42);
            this.meddigDateTime.Name = "meddigDateTime";
            this.meddigDateTime.Size = new System.Drawing.Size(200, 20);
            this.meddigDateTime.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Meddig";
            // 
            // kereses_Btn
            // 
            this.kereses_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.kereses_Btn.Location = new System.Drawing.Point(358, 196);
            this.kereses_Btn.Name = "kereses_Btn";
            this.kereses_Btn.Size = new System.Drawing.Size(167, 46);
            this.kereses_Btn.TabIndex = 6;
            this.kereses_Btn.Text = "Szűrés";
            this.kereses_Btn.UseVisualStyleBackColor = true;
            this.kereses_Btn.Click += new System.EventHandler(this.kereses_Btn_Click);
            // 
            // MettolMeddig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(564, 276);
            this.Controls.Add(this.kereses_Btn);
            this.Controls.Add(this.meddig_GB);
            this.Controls.Add(this.mettol_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MettolMeddig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szűrés dátummal";
            this.mettol_GB.ResumeLayout(false);
            this.mettol_GB.PerformLayout();
            this.meddig_GB.ResumeLayout(false);
            this.meddig_GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker mettolDateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mettol_GB;
        private System.Windows.Forms.GroupBox meddig_GB;
        private System.Windows.Forms.DateTimePicker meddigDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button kereses_Btn;
    }
}