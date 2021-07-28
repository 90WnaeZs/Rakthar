namespace Raktár
{
    partial class Jelszovaltas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jelszovaltas));
            this.change_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.email_Txtbox = new System.Windows.Forms.TextBox();
            this.regi_Txtbox = new System.Windows.Forms.TextBox();
            this.uj_Txtbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ujmegint_Txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // change_Btn
            // 
            this.change_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.change_Btn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.change_Btn.Location = new System.Drawing.Point(165, 172);
            this.change_Btn.Name = "change_Btn";
            this.change_Btn.Size = new System.Drawing.Size(201, 37);
            this.change_Btn.TabIndex = 0;
            this.change_Btn.Text = "Megváltoztatás";
            this.change_Btn.UseVisualStyleBackColor = true;
            this.change_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(94, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email cím:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(87, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Régi jelszó:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(101, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Új jelszó:";
            // 
            // email_Txtbox
            // 
            this.email_Txtbox.Location = new System.Drawing.Point(165, 37);
            this.email_Txtbox.MaxLength = 30;
            this.email_Txtbox.Name = "email_Txtbox";
            this.email_Txtbox.Size = new System.Drawing.Size(200, 20);
            this.email_Txtbox.TabIndex = 5;
            this.email_Txtbox.TextChanged += new System.EventHandler(this.email_Txtbox_TextChanged);
            // 
            // regi_Txtbox
            // 
            this.regi_Txtbox.Location = new System.Drawing.Point(165, 67);
            this.regi_Txtbox.MaxLength = 14;
            this.regi_Txtbox.Name = "regi_Txtbox";
            this.regi_Txtbox.Size = new System.Drawing.Size(200, 20);
            this.regi_Txtbox.TabIndex = 6;
            this.regi_Txtbox.TextChanged += new System.EventHandler(this.regi_Txtbox_TextChanged);
            // 
            // uj_Txtbox
            // 
            this.uj_Txtbox.Location = new System.Drawing.Point(165, 97);
            this.uj_Txtbox.MaxLength = 14;
            this.uj_Txtbox.Name = "uj_Txtbox";
            this.uj_Txtbox.Size = new System.Drawing.Size(200, 20);
            this.uj_Txtbox.TabIndex = 7;
            this.uj_Txtbox.UseSystemPasswordChar = true;
            this.uj_Txtbox.TextChanged += new System.EventHandler(this.uj_Txtbox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(418, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ujmegint_Txtbox
            // 
            this.ujmegint_Txtbox.Location = new System.Drawing.Point(165, 127);
            this.ujmegint_Txtbox.MaxLength = 14;
            this.ujmegint_Txtbox.Name = "ujmegint_Txtbox";
            this.ujmegint_Txtbox.Size = new System.Drawing.Size(200, 20);
            this.ujmegint_Txtbox.TabIndex = 11;
            this.ujmegint_Txtbox.UseSystemPasswordChar = true;
            this.ujmegint_Txtbox.TextChanged += new System.EventHandler(this.ujmegint_Txtbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(31, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Új jelszó mégegyszer:";
            // 
            // Jelszovaltas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(519, 240);
            this.Controls.Add(this.ujmegint_Txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uj_Txtbox);
            this.Controls.Add(this.regi_Txtbox);
            this.Controls.Add(this.email_Txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Jelszovaltas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jelszó változtatás";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Jelszovaltas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox email_Txtbox;
        private System.Windows.Forms.TextBox regi_Txtbox;
        private System.Windows.Forms.TextBox uj_Txtbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ujmegint_Txtbox;
        private System.Windows.Forms.Label label4;
    }
}