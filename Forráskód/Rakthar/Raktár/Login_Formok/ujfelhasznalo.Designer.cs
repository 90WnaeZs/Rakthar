namespace Raktár
{
    partial class Ujfelhasznalo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ujfelhasznalo));
            this.email_Txt = new System.Windows.Forms.TextBox();
            this.jelszo_Txt = new System.Windows.Forms.TextBox();
            this.felhasznalo_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reg_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.jelszomegint_Txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.munkakor_combo = new System.Windows.Forms.ComboBox();
            this.user_checked = new System.Windows.Forms.PictureBox();
            this.munkakor_checked = new System.Windows.Forms.PictureBox();
            this.email_checked = new System.Windows.Forms.PictureBox();
            this.password_checked = new System.Windows.Forms.PictureBox();
            this.pwagain_checked = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.munkakor_checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email_checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwagain_checked)).BeginInit();
            this.SuspendLayout();
            // 
            // email_Txt
            // 
            this.email_Txt.Location = new System.Drawing.Point(151, 83);
            this.email_Txt.MaxLength = 30;
            this.email_Txt.Name = "email_Txt";
            this.email_Txt.Size = new System.Drawing.Size(200, 20);
            this.email_Txt.TabIndex = 17;
            this.toolTip1.SetToolTip(this.email_Txt, "Add meg az email címed");
            this.email_Txt.TextChanged += new System.EventHandler(this.email_Txt_TextChanged);
            // 
            // jelszo_Txt
            // 
            this.jelszo_Txt.Location = new System.Drawing.Point(151, 109);
            this.jelszo_Txt.MaxLength = 14;
            this.jelszo_Txt.Name = "jelszo_Txt";
            this.jelszo_Txt.Size = new System.Drawing.Size(200, 20);
            this.jelszo_Txt.TabIndex = 15;
            this.toolTip1.SetToolTip(this.jelszo_Txt, "Minimum 8 karakter hosszú jelszó szükséges!");
            this.jelszo_Txt.UseSystemPasswordChar = true;
            this.jelszo_Txt.TextChanged += new System.EventHandler(this.jelszo_Txt_TextChanged);
            // 
            // felhasznalo_Txt
            // 
            this.felhasznalo_Txt.Location = new System.Drawing.Point(151, 31);
            this.felhasznalo_Txt.MaxLength = 30;
            this.felhasznalo_Txt.Name = "felhasznalo_Txt";
            this.felhasznalo_Txt.Size = new System.Drawing.Size(200, 20);
            this.felhasznalo_Txt.TabIndex = 14;
            this.toolTip1.SetToolTip(this.felhasznalo_Txt, "Add meg a felhasználóneved");
            this.felhasznalo_Txt.TextChanged += new System.EventHandler(this.felhasznalo_Txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(104, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(78, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Munkakör:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(100, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Jelszó:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Felhasználónév:";
            // 
            // reg_Btn
            // 
            this.reg_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reg_Btn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_Btn.Location = new System.Drawing.Point(152, 180);
            this.reg_Btn.Name = "reg_Btn";
            this.reg_Btn.Size = new System.Drawing.Size(199, 37);
            this.reg_Btn.TabIndex = 9;
            this.reg_Btn.Text = "Regisztráció";
            this.reg_Btn.UseVisualStyleBackColor = true;
            this.reg_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(386, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // jelszomegint_Txt
            // 
            this.jelszomegint_Txt.Location = new System.Drawing.Point(151, 135);
            this.jelszomegint_Txt.MaxLength = 14;
            this.jelszomegint_Txt.Name = "jelszomegint_Txt";
            this.jelszomegint_Txt.Size = new System.Drawing.Size(200, 20);
            this.jelszomegint_Txt.TabIndex = 20;
            this.toolTip1.SetToolTip(this.jelszomegint_Txt, "Minimum 8 karakter hosszú jelszó szükséges!");
            this.jelszomegint_Txt.UseSystemPasswordChar = true;
            this.jelszomegint_Txt.TextChanged += new System.EventHandler(this.jelszomegint_Txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(29, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Jelszó mégegyszer:";
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(276, 230);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(75, 23);
            this.reset_Btn.TabIndex = 22;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // munkakor_combo
            // 
            this.munkakor_combo.FormattingEnabled = true;
            this.munkakor_combo.Location = new System.Drawing.Point(151, 57);
            this.munkakor_combo.Name = "munkakor_combo";
            this.munkakor_combo.Size = new System.Drawing.Size(200, 21);
            this.munkakor_combo.TabIndex = 23;
            this.munkakor_combo.SelectedIndexChanged += new System.EventHandler(this.munkakor_combo_SelectedIndexChanged);
            // 
            // user_checked
            // 
            this.user_checked.Image = ((System.Drawing.Image)(resources.GetObject("user_checked.Image")));
            this.user_checked.Location = new System.Drawing.Point(358, 31);
            this.user_checked.Name = "user_checked";
            this.user_checked.Size = new System.Drawing.Size(22, 20);
            this.user_checked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user_checked.TabIndex = 24;
            this.user_checked.TabStop = false;
            this.user_checked.Visible = false;
            // 
            // munkakor_checked
            // 
            this.munkakor_checked.Image = ((System.Drawing.Image)(resources.GetObject("munkakor_checked.Image")));
            this.munkakor_checked.Location = new System.Drawing.Point(357, 58);
            this.munkakor_checked.Name = "munkakor_checked";
            this.munkakor_checked.Size = new System.Drawing.Size(22, 20);
            this.munkakor_checked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.munkakor_checked.TabIndex = 25;
            this.munkakor_checked.TabStop = false;
            this.munkakor_checked.Visible = false;
            // 
            // email_checked
            // 
            this.email_checked.Image = ((System.Drawing.Image)(resources.GetObject("email_checked.Image")));
            this.email_checked.Location = new System.Drawing.Point(358, 84);
            this.email_checked.Name = "email_checked";
            this.email_checked.Size = new System.Drawing.Size(22, 20);
            this.email_checked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.email_checked.TabIndex = 26;
            this.email_checked.TabStop = false;
            this.email_checked.Visible = false;
            // 
            // password_checked
            // 
            this.password_checked.Image = ((System.Drawing.Image)(resources.GetObject("password_checked.Image")));
            this.password_checked.Location = new System.Drawing.Point(357, 110);
            this.password_checked.Name = "password_checked";
            this.password_checked.Size = new System.Drawing.Size(22, 20);
            this.password_checked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.password_checked.TabIndex = 27;
            this.password_checked.TabStop = false;
            this.password_checked.Visible = false;
            // 
            // pwagain_checked
            // 
            this.pwagain_checked.Image = ((System.Drawing.Image)(resources.GetObject("pwagain_checked.Image")));
            this.pwagain_checked.Location = new System.Drawing.Point(357, 135);
            this.pwagain_checked.Name = "pwagain_checked";
            this.pwagain_checked.Size = new System.Drawing.Size(22, 20);
            this.pwagain_checked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pwagain_checked.TabIndex = 28;
            this.pwagain_checked.TabStop = false;
            this.pwagain_checked.Visible = false;
            // 
            // Ujfelhasznalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(525, 277);
            this.Controls.Add(this.pwagain_checked);
            this.Controls.Add(this.password_checked);
            this.Controls.Add(this.email_checked);
            this.Controls.Add(this.munkakor_checked);
            this.Controls.Add(this.user_checked);
            this.Controls.Add(this.munkakor_combo);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.jelszomegint_Txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.email_Txt);
            this.Controls.Add(this.jelszo_Txt);
            this.Controls.Add(this.felhasznalo_Txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reg_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ujfelhasznalo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Új felhasználó";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.munkakor_checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email_checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwagain_checked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reg_Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox email_Txt;
        private System.Windows.Forms.TextBox jelszo_Txt;
        private System.Windows.Forms.TextBox felhasznalo_Txt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox jelszomegint_Txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.ComboBox munkakor_combo;
        private System.Windows.Forms.PictureBox user_checked;
        private System.Windows.Forms.PictureBox munkakor_checked;
        private System.Windows.Forms.PictureBox email_checked;
        private System.Windows.Forms.PictureBox password_checked;
        private System.Windows.Forms.PictureBox pwagain_checked;

    }
}