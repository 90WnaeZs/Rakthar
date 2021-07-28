using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Al_Formok;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Gazdalkodo : Form
    {
        #region Form betöltés
        Adatbazis Adatbazis = new Adatbazis();
        Adatkezeles Adatkezeles = new Adatkezeles();
        Gazdalkodo g;
        public Gazdalkodo()
        {
            InitializeComponent();
            this.ActiveControl = search_Txtbox;
            timer1.Start();

            g = this;
        }
        #endregion

        #region Bejelentkezett felhasználó + pontos idő
        public string LabelText
        {
            get
            {
                return this.bejelentkezve_Lbl.Text;
            }
            set
            {
                this.bejelentkezve_Lbl.Text = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Adatbetöltő Radio Button-ök
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

            FormEllenorzo.GroupBox_kezelo("cikk_GB", main_GB);
        }
        private void rend_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.rendeles_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("rend_GB", main_GB);
        }
        private void beszállító_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.beszallito_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("besz_GB", main_GB);
        }
        private void karb_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.karb_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("karb_GB", main_GB);
        }
        private void selejtezes_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.selejtezes_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("selejt_GB", main_GB);
        }
        private void min_RB_CheckedChanged(object sender, EventArgs e)
        {
            Adatkezeles.MYSQL_lekerdezes(Adatbazis.min_query, this.dataGridView1);
            FormEllenorzo.GroupBox_kezelo("min_GB", main_GB);
        }
        #endregion

        #region Keresés
        private void TextChanged_Search_Load(object sender, EventArgs e)
        {
            searchData("");
        }

        private void search_Txtbox_TextChanged_1(object sender, EventArgs e)
        {
            searchData(search_Txtbox.Text);
        }

        public void searchData(string valueToFind)
        {
            using (MySqlConnection con = new MySqlConnection(Ipcim.constr))
            {
                try
                {
                    con.Open();
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
                    else if (beszállító_RB.Checked)
                    {
                        if (beszallitonev_bRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.beszallito_query + "WHERE Beszállító_név LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }
                        else if (varos_bRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.beszallito_query + "WHERE Város LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }
                        else if (cim_bRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.beszallito_query + "WHERE Cím LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }
                        else if (telefon_bRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.beszallito_query + "WHERE Telefonszám LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }
                    }
                    else if (selejtezes_RB.Checked)
                    {
                        if (cikknev_sRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.selejtezes_query + "WHERE Cikknév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }

                        else if (gyartoi_sRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.selejtezes_query + "WHERE Gyártói LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
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
                    else if (min_RB.Checked)
                    {
                        if (cikknev_mRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.min_query + "AND Cikknév LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }

                        else if (gyartoi_mRB.Checked)
                        {
                            Adatkezeles.datagrid_STRINGparam(Adatbazis.min_query + "AND Gyártói LIKE @search ", this.dataGridView1, "%" + valueToFind + "%");
                        }

                        else if (epulet_mRB.Checked)
                        {
                            Adatkezeles.datagrid_INTparam(Adatbazis.min_query + "AND Épület = @search ", this.dataGridView1, valueToFind);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            
            
        }
        #endregion

        #region Szűrés dátumra

        private void rendelve_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.g, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, null, datum_sRB);
                ido.Show();
            }
        }

        private void varhato_bRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.g, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, null, datum_sRB);
                ido.Show();
            }
        }

        private void karbantartva_kRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.g, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, null, datum_sRB);
                ido.Show();
            }
        }

        private void datum_sRB_CheckedChanged(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("MettolMeddig");

            if (!FormEllenorzo.isopen)
            {
                MettolMeddig ido = new MettolMeddig(this.g, this.dataGridView1, rendelve_bRB, varhato_bRB, karbantartva_kRB, null, datum_sRB);
                ido.Show();
            }
        }
        #endregion

        #region Alformok megnyitása
        private void hely_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Hely");

            if (!FormEllenorzo.isopen)
            {
                Hely hely = new Hely(this,this.dataGridView1);
                hely.Show();
            }
        }
        private void ujbesz_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Ujbeszallito");

            if (!FormEllenorzo.isopen)
            {
                Ujbeszallito uj = new Ujbeszallito();
                uj.Show();
            }
        }

        private void rendeles_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Rendeles");

            if (!FormEllenorzo.isopen)
            {
                Rendeles rend = new Rendeles();
                rend.Show();
            }
        }

        private void modositas_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Beszmod");

            if (!FormEllenorzo.isopen)
            {
                Beszmod bm = new Beszmod();
                bm.Show();
            }
        }

        private void torles_Btn_Click(object sender, EventArgs e)
        {
            FormEllenorzo.form_ellenorzes("Gazd_delete");

            if (!FormEllenorzo.isopen)
            {
                Gazd_delete gd = new Gazd_delete();
                gd.Show();
            }
        }

        #endregion

        #region Kilépés a Formból
        private void Gazdalkodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(g);
        }
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEllenorzo.vissza_Loginhoz(g);
        }
        #endregion

    }

}
