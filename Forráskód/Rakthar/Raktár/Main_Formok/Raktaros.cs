using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Al_Formok;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Raktaros : Form
    {
        #region Form indítás
        Raktaros r;
        public Raktaros()
        {
            InitializeComponent();
            this.ActiveControl = search_Txtbox;
            timer1.Start();
            r = this;
        }
        #endregion

        #region Bejelentkezett felhasználó + pontos idő
        public string LabelText
        {
            // Bejelentkezett személy
            get
            {
                return this.bejelentkezve_Lbl.Text;
            }
            set
            {
                this.bejelentkezve_Lbl.Text = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)  // Pontos idő
        {

            time_Lbl.Text = DateTime.Now.ToString();
        }

        
        #endregion

        #region Adatbetöltő RadioButton-ök

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(cikk_RB.Checked)
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

                //FormEllenorzo.GroupBox_kezelo2(this, "cikk_GB", main_GB, cikk_RB);
                FormEllenorzo.GroupBox_kezelo("cikk_GB", main_GB);
                Reset.ClearRadioButtons(this.r, cikk_RB);
            }

        }

        private void rend_RB_CheckedChanged(object sender, EventArgs e)
        {
            if(rend_RB.Checked)
            {
                Adatkezeles.MYSQL_lekerdezes(Adatbazis.rendeles_query, this.dataGridView1);
                //FormEllenorzo.GroupBox_kezelo2(this, "rend_GB", main_GB, rend_RB);
                FormEllenorzo.GroupBox_kezelo("rend_GB", main_GB);
                Reset.ClearRadioButtons(this.r, rend_RB);
            }
            
        }

        private void karb_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (karb_RB.Checked)
            {
                Adatkezeles.MYSQL_lekerdezes(Adatbazis.karb_query, this.dataGridView1);
                //FormEllenorzo.GroupBox_kezelo2(this, "karb_GB", main_GB, karb_RB);
                FormEllenorzo.GroupBox_kezelo("karb_GB", main_GB);
                Reset.ClearRadioButtons(this.r, karb_RB);
            }
        }

        private void gep_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes("SELECT * FROM gepek",this.dataGridView1);
            //FormEllenorzo.GroupBox_kezelo2(this, "gep_GB", main_GB, gep_RB);
            FormEllenorzo.GroupBox_kezelo("gep_GB", main_GB);
            Reset.ClearRadioButtons(this.r, gep_RB);
        }

        private void utem_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.utemezett_query, this.dataGridView1);
            //FormEllenorzo.GroupBox_kezelo2(this, "utem_GB", main_GB, utem_RB);
            FormEllenorzo.GroupBox_kezelo("utem_GB", main_GB);
            Reset.ClearRadioButtons(this.r, utem_RB);
        }
        #endregion

        #region Keresés az adatbázisban
        // Speciális keresés az adott táblán belül a keresőmező segítségével
        private void search_Txtbox_TextChanged(object sender, EventArgs e)
        {
            searchData(search_Txtbox.Text);
        }
        private void TextChanged_Search_Load(object sender, EventArgs e)
        {
            searchData("");
        }
        private void searchData(string valueToFind)
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
                else if (rend_RB.Checked)
                {
                    if (cikknev_bRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.rendeles_query + "WHERE Cikknév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                    else if (gyartoi_bRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.rendeles_query + "WHERE Gyártói LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                    }
                    else if (beszallito_bRB.Checked)
                    {
                        Adatkezeles.datagrid_STRINGparam(Adatbazis.rendeles_query + "WHERE Beszállító_név LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
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

        #region Alformok megnyítása
        
        private void ujcikk_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Ujcikk");

            if (!FormEllenorzo.isopen)
            {
                Ujcikk uj = new Ujcikk();
                uj.Show();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Selejtezes");

            if (!FormEllenorzo.isopen)
            {
                Selejtezes del = new Selejtezes();
                del.Show();
            }
        }


        private void bevitelBtn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Betarolas");

            if (!FormEllenorzo.isopen)
            {
                Betarolas be = new Betarolas();
                be.Show();
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
            FormEllenorzo.form_ellenorzes("Cikkmod");

            if (!FormEllenorzo.isopen)
            {
                Cikkmod mod = new Cikkmod();
                mod.Show();
            }
        }

        private void torles_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Torles");

            if (!FormEllenorzo.isopen)
            {
                Torles tor = new Torles();
                tor.Show();
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

        #region Szűrés dátumra
        private void rendelve_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.r, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void varhato_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.r, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void karbantartva_kRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.r, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }

        private void datum_uRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.r, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, datum_uRB, null);
                ido.Show();
            }
        }
        #endregion

        #region Form bezárása, és visszatérés a Loginhoz
        private void Raktaros_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(r);
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(r);
        }

        #endregion

    }
}
