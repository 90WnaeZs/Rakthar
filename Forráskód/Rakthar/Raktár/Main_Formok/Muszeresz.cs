using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Raktár.Main_Formok;
using Raktár.Közös_osztályok;
using Raktár.Al_Formok;

namespace Raktár
{
    public partial class Muszeresz : Form
    {
        #region Form betöltés
        Adatbazis Adatbazis = new Adatbazis();
        Adatkezeles Adatkezeles = new Adatkezeles();
        Muszeresz m;
        public Muszeresz()
        {
            InitializeComponent();
            this.ActiveControl = kereses_Txtbox;
            timer1.Start();
            m = this;
        }
        #endregion

        #region Bejelentkezett felhasználó + pontos idő
        public string LabelText
        {
            get
            {
                return this.bejelentkezve2_Lbl.Text;
            }
            set
            {
                this.bejelentkezve2_Lbl.Text = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time_Lbl.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Keresés
        private void TextChanged_Search_Load(object sender, EventArgs e)
        {
            searchData("");
        }
        private void kereses_Txtbox_TextChanged(object sender, EventArgs e)
        {
            searchData(kereses_Txtbox.Text);
        }
        public void searchData(string valueToFind)
        {
            try
            {
                if (cikk_RB.Checked)
                {
                    if (cikknev_cRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.cikk_query + "WHERE Cikknév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (gyartoi_cRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.cikk_query + "WHERE Gyártói LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (tipus_cRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.cikk_query + "WHERE Típus LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (beszallito_cRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.cikk_query + "WHERE Beszállító_név LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                }

                else if (karb_RB.Checked)
                {
                    if (gepnev_kRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.karb_query + "WHERE Gépnév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (azonosito_kRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.karb_query + "WHERE Azonosítószám LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (cikknév_kRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.karb_query + "WHERE Cikknév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                    else if (karbantarto_kRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.karb_query + "WHERE Karbantartó LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                }

                else if (gep_RB.Checked)
                {
                    if (gepnev_gRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam("SELECT * FROM gepek WHERE Gépnév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }

                    else if (azonosito_gRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam("SELECT * FROM gepek WHERE Azonosítószám LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                }

                else if (utem_RB.Checked)
                {
                    if (gepnev_uRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.utemezett_query + "WHERE Azonosítószám LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        #endregion

        #region RadioButton-ök
        private void cikk_RB_CheckedChanged(object sender, EventArgs e)
        {

            Adatkezeles.MYSQL_lekerdezes(Adatbazis.cikk_query, this.dataGridView1);

            // külön indexelés, mert, ha nincs beállítva, az Épület oszlop mindig elmozgott más indexre
            dataGridView1.Columns["Cikknév"].DisplayIndex = 0;
            dataGridView1.Columns["Gyártói"].DisplayIndex = 1;
            dataGridView1.Columns["Típus"].DisplayIndex = 2;
            dataGridView1.Columns["Ár_Forint"].DisplayIndex = 3;
            dataGridView1.Columns["Mennyiség"].DisplayIndex = 4;
            dataGridView1.Columns["Egység"].DisplayIndex = 5;
            dataGridView1.Columns["Beszállító"].DisplayIndex = 6;
            dataGridView1.Columns["Minimum"].DisplayIndex = 7;
            dataGridView1.Columns["Maximum"].DisplayIndex = 8;
            dataGridView1.Columns["Épület"].DisplayIndex = 9;
            dataGridView1.Columns["Raktár"].DisplayIndex = 10;
            dataGridView1.Columns["Oszlop"].DisplayIndex = 11;
            dataGridView1.Columns["Polc"].DisplayIndex = 12;
            dataGridView1.Columns["Box"].DisplayIndex = 13;

            FormEllenorzo.GroupBox_kezelo("cikk_GB", this.main_GB);
        }

        private void karb_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.karb_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("karb_GB", main_GB);
        }
        private void utem_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.utemezett_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("utem_GB", main_GB);
            Reset.ClearRadioButtons(this, utem_RB);
        }
        private void gep_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes("SELECT * FROM gepek", this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("gep_GB", main_GB);
        }

        private void rend_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.rendeles_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("rend_GB", main_GB);
        }
        #endregion

        #region Alformok betöltése
        private void utemezes_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Utemezes");

            if (!FormEllenorzo.isopen)
            {
                Utemezes utem = new Utemezes();
                utem.Show();
            }
        }
        private void ujgep_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Ujgep");

            if (!FormEllenorzo.isopen)
            {
                Ujgep uj = new Ujgep();
                uj.Show();
            }
        }

        private void kiiras_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Kiiras");

            if (!FormEllenorzo.isopen)
            {
                Kiiras ki = new Kiiras();
                ki.Show();
            }
        }
        private void modositas_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("GepModositas");

            if (!FormEllenorzo.isopen)
            {
                GepModositas mod = new GepModositas();
                mod.Show();
            }
        }
        private void delete_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Musz_delete");

            if (!FormEllenorzo.isopen)
            {
                Musz_delete del = new Musz_delete();
                del.Show();
            }
        }
        private void hely_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Hely");

            if (!FormEllenorzo.isopen)
            {
                Hely hely = new Hely(this, this.dataGridView1);
                hely.Show();
            }
        }
        #endregion

        #region Form bezárása
        private void Muszeresz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(m);
        }
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(m);
        }

        #endregion

        private void karbantartva_kRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void datum_uRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void rendelve_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void varhato_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

    }
}
