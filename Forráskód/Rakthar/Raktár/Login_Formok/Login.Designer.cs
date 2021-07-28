namespace Raktár
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginFrm_loginBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Login_timelbl = new System.Windows.Forms.Label();
            this.lgn_passwordTxt = new System.Windows.Forms.TextBox();
            this.lgn_username_combo = new System.Windows.Forms.ComboBox();
            this.jelszovaltas_Btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ujfelhasznalo_Btn = new System.Windows.Forms.Button();
            this.ipcim_Btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginFrm_loginBtn
            // 
            this.loginFrm_loginBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginFrm_loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginFrm_loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginFrm_loginBtn.Font = new System.Drawing.Font("OCR A Std", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFrm_loginBtn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.loginFrm_loginBtn.Location = new System.Drawing.Point(207, 97);
            this.loginFrm_loginBtn.Name = "loginFrm_loginBtn";
            this.loginFrm_loginBtn.Size = new System.Drawing.Size(240, 54);
            this.loginFrm_loginBtn.TabIndex = 5;
            this.loginFrm_loginBtn.Text = "Bejelentkezés";
            this.toolTip1.SetToolTip(this.loginFrm_loginBtn, "Nyomja meg a bejelentkezéshez");
            this.loginFrm_loginBtn.UseVisualStyleBackColor = false;
            this.loginFrm_loginBtn.Click += new System.EventHandler(this.loginFrm_loginBtn_Click);
            // 
            // Login_timelbl
            // 
            this.Login_timelbl.AutoSize = true;
            this.Login_timelbl.BackColor = System.Drawing.Color.Transparent;
            this.Login_timelbl.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Login_timelbl.ForeColor = System.Drawing.Color.Black;
            this.Login_timelbl.Location = new System.Drawing.Point(7, 45);
            this.Login_timelbl.Name = "Login_timelbl";
            this.Login_timelbl.Size = new System.Drawing.Size(27, 17);
            this.Login_timelbl.TabIndex = 8;
            this.Login_timelbl.Text = "idő";
            this.toolTip1.SetToolTip(this.Login_timelbl, "Pontos idő");
            // 
            // lgn_passwordTxt
            // 
            this.lgn_passwordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lgn_passwordTxt.Location = new System.Drawing.Point(207, 61);
            this.lgn_passwordTxt.MaxLength = 50;
            this.lgn_passwordTxt.Name = "lgn_passwordTxt";
            this.lgn_passwordTxt.Size = new System.Drawing.Size(240, 30);
            this.lgn_passwordTxt.TabIndex = 1;
            this.toolTip1.SetToolTip(this.lgn_passwordTxt, "Adja meg a jelszavad");
            this.lgn_passwordTxt.UseSystemPasswordChar = true;
            this.lgn_passwordTxt.TextChanged += new System.EventHandler(this.lgn_passwordTxt_TextChanged);
            this.lgn_passwordTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lgn_passwordTxt_KeyDown);
            // 
            // lgn_username_combo
            // 
            this.lgn_username_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lgn_username_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lgn_username_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lgn_username_combo.FormattingEnabled = true;
            this.lgn_username_combo.Location = new System.Drawing.Point(207, 22);
            this.lgn_username_combo.Name = "lgn_username_combo";
            this.lgn_username_combo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lgn_username_combo.Size = new System.Drawing.Size(240, 33);
            this.lgn_username_combo.TabIndex = 11;
            this.toolTip1.SetToolTip(this.lgn_username_combo, "Írja be a felhasználónevét");
            this.lgn_username_combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lgn_username_combo_KeyDown);
            // 
            // jelszovaltas_Btn
            // 
            this.jelszovaltas_Btn.BackColor = System.Drawing.Color.White;
            this.jelszovaltas_Btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.jelszovaltas_Btn.Location = new System.Drawing.Point(161, 3);
            this.jelszovaltas_Btn.Name = "jelszovaltas_Btn";
            this.jelszovaltas_Btn.Size = new System.Drawing.Size(140, 28);
            this.jelszovaltas_Btn.TabIndex = 7;
            this.jelszovaltas_Btn.Text = "Jelszó változtatás";
            this.jelszovaltas_Btn.UseVisualStyleBackColor = false;
            this.jelszovaltas_Btn.Click += new System.EventHandler(this.jelszoBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ujfelhasznalo_Btn
            // 
            this.ujfelhasznalo_Btn.BackColor = System.Drawing.Color.White;
            this.ujfelhasznalo_Btn.Location = new System.Drawing.Point(3, 3);
            this.ujfelhasznalo_Btn.Name = "ujfelhasznalo_Btn";
            this.ujfelhasznalo_Btn.Size = new System.Drawing.Size(152, 28);
            this.ujfelhasznalo_Btn.TabIndex = 9;
            this.ujfelhasznalo_Btn.Text = "Új felhasználó";
            this.ujfelhasznalo_Btn.UseVisualStyleBackColor = false;
            this.ujfelhasznalo_Btn.Click += new System.EventHandler(this.ujfelhasznalo_Btn_Click);
            // 
            // ipcim_Btn
            // 
            this.ipcim_Btn.BackColor = System.Drawing.Color.White;
            this.ipcim_Btn.Location = new System.Drawing.Point(307, 3);
            this.ipcim_Btn.Name = "ipcim_Btn";
            this.ipcim_Btn.Size = new System.Drawing.Size(89, 28);
            this.ipcim_Btn.TabIndex = 10;
            this.ipcim_Btn.Text = "IP";
            this.ipcim_Btn.UseVisualStyleBackColor = false;
            this.ipcim_Btn.Click += new System.EventHandler(this.ipcim_Btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Login_timelbl);
            this.panel2.Controls.Add(this.jelszovaltas_Btn);
            this.panel2.Controls.Add(this.ujfelhasznalo_Btn);
            this.panel2.Controls.Add(this.ipcim_Btn);
            this.panel2.Location = new System.Drawing.Point(44, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 66);
            this.panel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(51, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Felhasználónév";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(132, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Jelszó";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(490, 282);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lgn_passwordTxt);
            this.Controls.Add(this.lgn_username_combo);
            this.Controls.Add(this.loginFrm_loginBtn);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bejelentkezés";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button loginFrm_loginBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button jelszovaltas_Btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Login_timelbl;
        private System.Windows.Forms.Button ujfelhasznalo_Btn;
        private System.Windows.Forms.Button ipcim_Btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox lgn_username_combo;
        public System.Windows.Forms.TextBox lgn_passwordTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}