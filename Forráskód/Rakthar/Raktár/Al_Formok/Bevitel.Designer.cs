namespace Raktár
{
    partial class Betarolas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Betarolas));
            this.Bevetel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mennyi_num = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ujhely_RB = new System.Windows.Forms.RadioButton();
            this.korabbi_RB = new System.Windows.Forms.RadioButton();
            this.box_combo = new System.Windows.Forms.ComboBox();
            this.polc_combo = new System.Windows.Forms.ComboBox();
            this.oszlop_combo = new System.Windows.Forms.ComboBox();
            this.raktar_combo = new System.Windows.Forms.ComboBox();
            this.epulet_combo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.downarrow = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gyartoi_combo = new System.Windows.Forms.ComboBox();
            this.cikknev_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.reset_Btn = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mennyi_num)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downarrow)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bevetel
            // 
            this.Bevetel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bevetel.Location = new System.Drawing.Point(138, 460);
            this.Bevetel.Name = "Bevetel";
            this.Bevetel.Size = new System.Drawing.Size(190, 40);
            this.Bevetel.TabIndex = 24;
            this.Bevetel.Text = "Mentés";
            this.Bevetel.UseVisualStyleBackColor = true;
            this.Bevetel.Click += new System.EventHandler(this.Bevetel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mennyi_num);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(5, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 109);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            // 
            // mennyi_num
            // 
            this.mennyi_num.Location = new System.Drawing.Point(99, 62);
            this.mennyi_num.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mennyi_num.Name = "mennyi_num";
            this.mennyi_num.Size = new System.Drawing.Size(191, 20);
            this.mennyi_num.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mennyit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Mennyiség:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ujhely_RB);
            this.groupBox2.Controls.Add(this.korabbi_RB);
            this.groupBox2.Controls.Add(this.box_combo);
            this.groupBox2.Controls.Add(this.polc_combo);
            this.groupBox2.Controls.Add(this.oszlop_combo);
            this.groupBox2.Controls.Add(this.raktar_combo);
            this.groupBox2.Controls.Add(this.epulet_combo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.downarrow);
            this.groupBox2.Location = new System.Drawing.Point(5, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 196);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // ujhely_RB
            // 
            this.ujhely_RB.AutoSize = true;
            this.ujhely_RB.Location = new System.Drawing.Point(222, 19);
            this.ujhely_RB.Name = "ujhely_RB";
            this.ujhely_RB.Size = new System.Drawing.Size(66, 17);
            this.ujhely_RB.TabIndex = 76;
            this.ujhely_RB.TabStop = true;
            this.ujhely_RB.Text = "Új helyre";
            this.ujhely_RB.UseVisualStyleBackColor = true;
            this.ujhely_RB.CheckedChanged += new System.EventHandler(this.ujhely_RB_CheckedChanged);
            // 
            // korabbi_RB
            // 
            this.korabbi_RB.AutoSize = true;
            this.korabbi_RB.Location = new System.Drawing.Point(99, 19);
            this.korabbi_RB.Name = "korabbi_RB";
            this.korabbi_RB.Size = new System.Drawing.Size(92, 17);
            this.korabbi_RB.TabIndex = 75;
            this.korabbi_RB.TabStop = true;
            this.korabbi_RB.Text = "Korábbi helyre";
            this.korabbi_RB.UseVisualStyleBackColor = true;
            this.korabbi_RB.CheckedChanged += new System.EventHandler(this.korabbi_RB_CheckedChanged);
            // 
            // box_combo
            // 
            this.box_combo.FormattingEnabled = true;
            this.box_combo.Location = new System.Drawing.Point(99, 156);
            this.box_combo.Name = "box_combo";
            this.box_combo.Size = new System.Drawing.Size(191, 21);
            this.box_combo.TabIndex = 72;
            // 
            // polc_combo
            // 
            this.polc_combo.FormattingEnabled = true;
            this.polc_combo.Location = new System.Drawing.Point(99, 131);
            this.polc_combo.Name = "polc_combo";
            this.polc_combo.Size = new System.Drawing.Size(191, 21);
            this.polc_combo.TabIndex = 71;
            this.polc_combo.TextChanged += new System.EventHandler(this.polc_combo_TextChanged);
            // 
            // oszlop_combo
            // 
            this.oszlop_combo.FormattingEnabled = true;
            this.oszlop_combo.Location = new System.Drawing.Point(99, 106);
            this.oszlop_combo.Name = "oszlop_combo";
            this.oszlop_combo.Size = new System.Drawing.Size(191, 21);
            this.oszlop_combo.TabIndex = 70;
            this.oszlop_combo.TextChanged += new System.EventHandler(this.oszlop_combo_TextChanged);
            // 
            // raktar_combo
            // 
            this.raktar_combo.FormattingEnabled = true;
            this.raktar_combo.Location = new System.Drawing.Point(99, 81);
            this.raktar_combo.Name = "raktar_combo";
            this.raktar_combo.Size = new System.Drawing.Size(191, 21);
            this.raktar_combo.TabIndex = 69;
            this.raktar_combo.TextChanged += new System.EventHandler(this.raktar_combo_TextChanged);
            // 
            // epulet_combo
            // 
            this.epulet_combo.FormattingEnabled = true;
            this.epulet_combo.Location = new System.Drawing.Point(99, 56);
            this.epulet_combo.Name = "epulet_combo";
            this.epulet_combo.Size = new System.Drawing.Size(191, 21);
            this.epulet_combo.TabIndex = 68;
            this.epulet_combo.TextChanged += new System.EventHandler(this.epulet_combo_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "Hova";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Épület:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Raktár:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Oszlop:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Polc:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Box:";
            // 
            // downarrow
            // 
            this.downarrow.Image = ((System.Drawing.Image)(resources.GetObject("downarrow.Image")));
            this.downarrow.Location = new System.Drawing.Point(7, 56);
            this.downarrow.Name = "downarrow";
            this.downarrow.Size = new System.Drawing.Size(42, 113);
            this.downarrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.downarrow.TabIndex = 77;
            this.downarrow.TabStop = false;
            this.downarrow.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gyartoi_combo);
            this.groupBox1.Controls.Add(this.cikknev_combo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 119);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // gyartoi_combo
            // 
            this.gyartoi_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gyartoi_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gyartoi_combo.FormattingEnabled = true;
            this.gyartoi_combo.Location = new System.Drawing.Point(99, 77);
            this.gyartoi_combo.Name = "gyartoi_combo";
            this.gyartoi_combo.Size = new System.Drawing.Size(190, 21);
            this.gyartoi_combo.TabIndex = 63;
            this.gyartoi_combo.SelectedIndexChanged += new System.EventHandler(this.gyartoi_combo_SelectedIndexChanged);
            // 
            // cikknev_combo
            // 
            this.cikknev_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cikknev_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cikknev_combo.FormattingEnabled = true;
            this.cikknev_combo.Location = new System.Drawing.Point(99, 52);
            this.cikknev_combo.Name = "cikknev_combo";
            this.cikknev_combo.Size = new System.Drawing.Size(190, 21);
            this.cikknev_combo.TabIndex = 62;
            this.cikknev_combo.SelectedIndexChanged += new System.EventHandler(this.cikkNev_combo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cikknév:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Gyártói:";
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(5, 460);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(93, 40);
            this.reset_Btn.TabIndex = 45;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // Betarolas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(335, 558);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Bevetel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Betarolas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Betárolás";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bevitel_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mennyi_num)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downarrow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bevetel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox box_combo;
        private System.Windows.Forms.ComboBox polc_combo;
        private System.Windows.Forms.ComboBox oszlop_combo;
        private System.Windows.Forms.ComboBox raktar_combo;
        private System.Windows.Forms.ComboBox epulet_combo;
        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.ComboBox cikknev_combo;
        private System.Windows.Forms.NumericUpDown mennyi_num;
        private System.Windows.Forms.ComboBox gyartoi_combo;
        private System.Windows.Forms.RadioButton ujhely_RB;
        private System.Windows.Forms.RadioButton korabbi_RB;
        private System.Windows.Forms.PictureBox downarrow;
    }
}