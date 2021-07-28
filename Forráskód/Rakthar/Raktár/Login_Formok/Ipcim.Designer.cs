namespace Raktár
{
    partial class Ipcim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ipcim));
            this.mentes_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipcim_Lbl = new System.Windows.Forms.Label();
            this.ipcim_txtbox = new System.Windows.Forms.TextBox();
            this.port_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.user_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pw_txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mentes_Btn
            // 
            this.mentes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mentes_Btn.Location = new System.Drawing.Point(194, 181);
            this.mentes_Btn.Name = "mentes_Btn";
            this.mentes_Btn.Size = new System.Drawing.Size(104, 33);
            this.mentes_Btn.TabIndex = 0;
            this.mentes_Btn.Text = "Mentés";
            this.mentes_Btn.UseVisualStyleBackColor = true;
            this.mentes_Btn.Click += new System.EventHandler(this.mentes_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(67, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP cím:";
            // 
            // ipcim_Lbl
            // 
            this.ipcim_Lbl.AutoSize = true;
            this.ipcim_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ipcim_Lbl.Location = new System.Drawing.Point(12, 239);
            this.ipcim_Lbl.Name = "ipcim_Lbl";
            this.ipcim_Lbl.Size = new System.Drawing.Size(47, 15);
            this.ipcim_Lbl.TabIndex = 3;
            this.ipcim_Lbl.Text = "IP cím: ";
            // 
            // ipcim_txtbox
            // 
            this.ipcim_txtbox.Location = new System.Drawing.Point(127, 37);
            this.ipcim_txtbox.MaxLength = 20;
            this.ipcim_txtbox.Name = "ipcim_txtbox";
            this.ipcim_txtbox.Size = new System.Drawing.Size(171, 20);
            this.ipcim_txtbox.TabIndex = 4;
            // 
            // port_txtbox
            // 
            this.port_txtbox.Location = new System.Drawing.Point(127, 73);
            this.port_txtbox.MaxLength = 4;
            this.port_txtbox.Name = "port_txtbox";
            this.port_txtbox.Size = new System.Drawing.Size(171, 20);
            this.port_txtbox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(81, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // user_txtbox
            // 
            this.user_txtbox.Location = new System.Drawing.Point(127, 109);
            this.user_txtbox.MaxLength = 14;
            this.user_txtbox.Name = "user_txtbox";
            this.user_txtbox.Size = new System.Drawing.Size(171, 20);
            this.user_txtbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(38, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // pw_txtbox
            // 
            this.pw_txtbox.Location = new System.Drawing.Point(127, 145);
            this.pw_txtbox.MaxLength = 14;
            this.pw_txtbox.Name = "pw_txtbox";
            this.pw_txtbox.PasswordChar = '*';
            this.pw_txtbox.Size = new System.Drawing.Size(171, 20);
            this.pw_txtbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(41, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password:";
            // 
            // Ipcim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(380, 263);
            this.Controls.Add(this.pw_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user_txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.port_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipcim_txtbox);
            this.Controls.Add(this.ipcim_Lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mentes_Btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ipcim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP cím beállítás";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mentes_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ipcim_Lbl;
        private System.Windows.Forms.TextBox ipcim_txtbox;
        private System.Windows.Forms.TextBox port_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pw_txtbox;
        private System.Windows.Forms.Label label4;
    }
}