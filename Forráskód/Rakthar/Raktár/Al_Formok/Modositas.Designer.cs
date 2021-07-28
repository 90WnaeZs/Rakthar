namespace Raktár
{
    partial class Cikkmod
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gyartoi_combo = new System.Windows.Forms.ComboBox();
            this.cikknev_combo = new System.Windows.Forms.ComboBox();
            this.mentes_Btn = new System.Windows.Forms.Button();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.betoltes_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.beszallito_combo = new System.Windows.Forms.ComboBox();
            this.tipus_combo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.max_num = new System.Windows.Forms.NumericUpDown();
            this.min_num = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.egyseg_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ujcikknev_txt = new System.Windows.Forms.TextBox();
            this.ujgyartoi_txt = new System.Windows.Forms.TextBox();
            this.ar_num = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.max_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ar_num)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(75, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Gyártói:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(72, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 58;
            this.label2.Text = "Cikknév:";
            // 
            // gyartoi_combo
            // 
            this.gyartoi_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gyartoi_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gyartoi_combo.FormattingEnabled = true;
            this.gyartoi_combo.Location = new System.Drawing.Point(139, 61);
            this.gyartoi_combo.Name = "gyartoi_combo";
            this.gyartoi_combo.Size = new System.Drawing.Size(192, 21);
            this.gyartoi_combo.TabIndex = 73;
            this.gyartoi_combo.SelectedIndexChanged += new System.EventHandler(this.gyartoi_combo_SelectedIndexChanged);
            // 
            // cikknev_combo
            // 
            this.cikknev_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cikknev_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cikknev_combo.FormattingEnabled = true;
            this.cikknev_combo.Location = new System.Drawing.Point(139, 34);
            this.cikknev_combo.Name = "cikknev_combo";
            this.cikknev_combo.Size = new System.Drawing.Size(192, 21);
            this.cikknev_combo.TabIndex = 72;
            this.cikknev_combo.SelectedIndexChanged += new System.EventHandler(this.cikknev_combo_SelectedIndexChanged);
            // 
            // mentes_Btn
            // 
            this.mentes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mentes_Btn.Location = new System.Drawing.Point(140, 409);
            this.mentes_Btn.Name = "mentes_Btn";
            this.mentes_Btn.Size = new System.Drawing.Size(194, 53);
            this.mentes_Btn.TabIndex = 84;
            this.mentes_Btn.Text = "Mentés";
            this.mentes_Btn.UseVisualStyleBackColor = true;
            this.mentes_Btn.Click += new System.EventHandler(this.mentes_Btn_Click);
            // 
            // reset_Btn
            // 
            this.reset_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.reset_Btn.Location = new System.Drawing.Point(33, 409);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(85, 53);
            this.reset_Btn.TabIndex = 91;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // betoltes_Btn
            // 
            this.betoltes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.betoltes_Btn.Location = new System.Drawing.Point(169, 88);
            this.betoltes_Btn.Name = "betoltes_Btn";
            this.betoltes_Btn.Size = new System.Drawing.Size(136, 43);
            this.betoltes_Btn.TabIndex = 92;
            this.betoltes_Btn.Text = "Adatok betöltése";
            this.betoltes_Btn.UseVisualStyleBackColor = true;
            this.betoltes_Btn.Click += new System.EventHandler(this.betoltes_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(86, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 93;
            this.label4.Text = "Típus:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(61, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 94;
            this.label14.Text = "Beszállító:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(27, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 17);
            this.label13.TabIndex = 95;
            this.label13.Text = "Egységár ( Ft ):";
            // 
            // beszallito_combo
            // 
            this.beszallito_combo.FormattingEnabled = true;
            this.beszallito_combo.Location = new System.Drawing.Point(139, 241);
            this.beszallito_combo.Name = "beszallito_combo";
            this.beszallito_combo.Size = new System.Drawing.Size(191, 21);
            this.beszallito_combo.TabIndex = 98;
            // 
            // tipus_combo
            // 
            this.tipus_combo.FormattingEnabled = true;
            this.tipus_combo.Location = new System.Drawing.Point(139, 210);
            this.tipus_combo.Name = "tipus_combo";
            this.tipus_combo.Size = new System.Drawing.Size(191, 21);
            this.tipus_combo.TabIndex = 97;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label17.Location = new System.Drawing.Point(55, 302);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 17);
            this.label17.TabIndex = 105;
            this.label17.Text = "M. Egység:";
            // 
            // max_num
            // 
            this.max_num.Location = new System.Drawing.Point(139, 363);
            this.max_num.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.max_num.Name = "max_num";
            this.max_num.Size = new System.Drawing.Size(191, 20);
            this.max_num.TabIndex = 103;
            // 
            // min_num
            // 
            this.min_num.Location = new System.Drawing.Point(139, 333);
            this.min_num.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.min_num.Name = "min_num";
            this.min_num.Size = new System.Drawing.Size(191, 20);
            this.min_num.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(102, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 17);
            this.label11.TabIndex = 100;
            this.label11.Text = "Min:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(99, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 101;
            this.label12.Text = "Max:";
            // 
            // egyseg_combo
            // 
            this.egyseg_combo.FormattingEnabled = true;
            this.egyseg_combo.Location = new System.Drawing.Point(139, 302);
            this.egyseg_combo.Name = "egyseg_combo";
            this.egyseg_combo.Size = new System.Drawing.Size(191, 21);
            this.egyseg_combo.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(72, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 107;
            this.label1.Text = "Cikknév:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(75, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "Gyártói:";
            // 
            // ujcikknev_txt
            // 
            this.ujcikknev_txt.Location = new System.Drawing.Point(139, 150);
            this.ujcikknev_txt.MaxLength = 30;
            this.ujcikknev_txt.Name = "ujcikknev_txt";
            this.ujcikknev_txt.Size = new System.Drawing.Size(191, 20);
            this.ujcikknev_txt.TabIndex = 109;
            // 
            // ujgyartoi_txt
            // 
            this.ujgyartoi_txt.Location = new System.Drawing.Point(139, 180);
            this.ujgyartoi_txt.MaxLength = 20;
            this.ujgyartoi_txt.Name = "ujgyartoi_txt";
            this.ujgyartoi_txt.Size = new System.Drawing.Size(191, 20);
            this.ujgyartoi_txt.TabIndex = 110;
            // 
            // ar_num
            // 
            this.ar_num.Location = new System.Drawing.Point(139, 272);
            this.ar_num.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ar_num.Name = "ar_num";
            this.ar_num.Size = new System.Drawing.Size(191, 20);
            this.ar_num.TabIndex = 111;
            // 
            // Cikkmod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(378, 496);
            this.Controls.Add(this.ar_num);
            this.Controls.Add(this.ujgyartoi_txt);
            this.Controls.Add(this.ujcikknev_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.egyseg_combo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.max_num);
            this.Controls.Add(this.min_num);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.beszallito_combo);
            this.Controls.Add(this.tipus_combo);
            this.Controls.Add(this.betoltes_Btn);
            this.Controls.Add(this.gyartoi_combo);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.cikknev_combo);
            this.Controls.Add(this.mentes_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Cikkmod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módosítás";
            ((System.ComponentModel.ISupportInitialize)(this.max_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ar_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox gyartoi_combo;
        private System.Windows.Forms.ComboBox cikknev_combo;
        private System.Windows.Forms.Button mentes_Btn;
        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.Button betoltes_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox beszallito_combo;
        private System.Windows.Forms.ComboBox tipus_combo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown max_num;
        private System.Windows.Forms.NumericUpDown min_num;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox egyseg_combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ujcikknev_txt;
        private System.Windows.Forms.TextBox ujgyartoi_txt;
        private System.Windows.Forms.NumericUpDown ar_num;
    }
}