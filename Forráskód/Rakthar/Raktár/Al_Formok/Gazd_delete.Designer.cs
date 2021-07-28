namespace Raktár
{
    partial class Gazd_delete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gazd_delete));
            this.delete_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.beszallito_combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // delete_Btn
            // 
            this.delete_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.delete_Btn.Location = new System.Drawing.Point(127, 96);
            this.delete_Btn.Name = "delete_Btn";
            this.delete_Btn.Size = new System.Drawing.Size(224, 45);
            this.delete_Btn.TabIndex = 0;
            this.delete_Btn.Text = "Törlés";
            this.delete_Btn.UseVisualStyleBackColor = true;
            this.delete_Btn.Click += new System.EventHandler(this.delete_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Beszállító név:";
            // 
            // beszallito_combo
            // 
            this.beszallito_combo.FormattingEnabled = true;
            this.beszallito_combo.Location = new System.Drawing.Point(127, 40);
            this.beszallito_combo.Name = "beszallito_combo";
            this.beszallito_combo.Size = new System.Drawing.Size(224, 21);
            this.beszallito_combo.TabIndex = 3;
            // 
            // Gazd_delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(398, 181);
            this.Controls.Add(this.beszallito_combo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delete_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Gazd_delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beszállító törlés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delete_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox beszallito_combo;
    }
}