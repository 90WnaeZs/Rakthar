using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Kiiras : Form
    {
        bool van_annyi = false;
        public Kiiras()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }
        private void kiiras_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    string text_mennyi = mennyit_num.Value.ToString();
                    int int_mennyi = Convert.ToInt32(mennyit_num.Value);
                    int int_mennyi_lesz = 0;

                    DataTable IDcikk_dt = new DataTable();
                    DataTable mennyiseg_dt = new DataTable();
                    DataTable IDgep_dt = new DataTable();

                    string QUERY_cikkID = "Select * From cikk Where Cikknév= @cikknev And Gyártói= @gyartoi";
                    string QUERY_SELECT_mennyiseg = "SELECT * FROM hely WHERE Cikk_ID=@cikkid AND Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc AND Box=@box";
                    string QUERY_UPDATE_mennyiseg = "UPDATE hely SET Mennyiség=@mennyi_lesz WHERE ID_Hely=@idhely";
                    string QUERY_gepID = "SELECT * FROM gepek WHERE Gépnév=@gepnev AND Azonosítószám=@azonosito";
                    string QUERY_INSERT_karb = "INSERT INTO karbantartas(Gép_ID,Cikk_ID,Mennyiség,Karbantartva) values(@karb_gepid,@karb_cikkid,@karb_mennyi,@karb_mikor)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_cikkID = new MySqlCommand(QUERY_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_cikkID = new MySqlDataAdapter(CMD_cikkID))
                    using (MySqlCommand CMD_mennyiseg = new MySqlCommand(QUERY_SELECT_mennyiseg, mysqlcon))
                    using (MySqlDataAdapter SDA_mennyiseg = new MySqlDataAdapter(CMD_mennyiseg))
                    using (MySqlCommand CMD_UPDATE_mennyiseg = new MySqlCommand(QUERY_UPDATE_mennyiseg, mysqlcon))
                    using (MySqlCommand CMD_gepID = new MySqlCommand(QUERY_gepID, mysqlcon))
                    using (MySqlDataAdapter SDA_gepID = new MySqlDataAdapter(CMD_gepID))
                    using (MySqlCommand CMD_INSERT_karb = new MySqlCommand(QUERY_INSERT_karb, mysqlcon))
                    {
                        mysqlcon.Open();

                        // CIKK ID
                        CMD_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                        CMD_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;
                        SDA_cikkID.Fill(IDcikk_dt);

                        DataRow cikkid_row;
                        string cikkID = "";
                        if (IDcikk_dt != null && IDcikk_dt.Rows.Count > 0)
                        {
                            cikkid_row = IDcikk_dt.Rows[0];
                            cikkID = cikkid_row["ID_cikk"].ToString();
                        }

                        // MENNYI VAN
                        CMD_mennyiseg.Parameters.Add("@cikkid", MySqlDbType.Int32).Value = Convert.ToInt32(cikkID);
                        CMD_mennyiseg.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                        CMD_mennyiseg.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar_combo.Text);
                        CMD_mennyiseg.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop_combo.Text);
                        CMD_mennyiseg.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc_combo.Text);
                        CMD_mennyiseg.Parameters.Add("@box", MySqlDbType.Int32).Value = Convert.ToInt32(box_combo.Text);
                        SDA_mennyiseg.Fill(mennyiseg_dt);

                        DataRow mennyiseg_row;
                        string mennyi_van = "";
                        if (mennyiseg_dt != null && mennyiseg_dt.Rows.Count > 0)
                        {
                            mennyiseg_row = mennyiseg_dt.Rows[0];
                            mennyi_van = mennyiseg_row["Mennyiség"].ToString();
                        }
                        int int_mennyi_van = Convert.ToInt32(mennyi_van);

                        if (int_mennyi_van > 0 && ((int_mennyi_van - int_mennyi) > 0))  // SZÁMOLÁS, HOGY MENNYI LESZ BELŐLE
                        {
                            van_annyi = true;
                            int_mennyi_lesz = int_mennyi_van - int_mennyi;
                        }
                        else if (int_mennyi_van < int_mennyi)
                        {
                            van_annyi = false;
                            MessageBox.Show("Nincs ennyi belőle!");
                        }

                        // HELY ID
                        DataRow helyID_row;
                        string helyID = "";
                        if (mennyiseg_dt != null && mennyiseg_dt.Rows.Count > 0)
                        {
                            helyID_row = mennyiseg_dt.Rows[0];
                            helyID = helyID_row["ID_Hely"].ToString();
                        }

                        // GEP ID
                        CMD_gepID.Parameters.Add("@gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                        CMD_gepID.Parameters.Add("@azonosito", MySqlDbType.String).Value = azonosito_combo.Text;
                        SDA_gepID.Fill(IDgep_dt);

                        DataRow gepid_row;
                        string gepID = "";
                        if (IDgep_dt != null && IDgep_dt.Rows.Count > 0)
                        {
                            gepid_row = IDgep_dt.Rows[0];
                            gepID = gepid_row["ID_Gép"].ToString();
                        }

                        // MENNYISÉG BEVITELE
                        if (van_annyi)
                        {
                            CMD_UPDATE_mennyiseg.Parameters.Add("@mennyi_lesz", MySqlDbType.Int32).Value = Convert.ToInt32(int_mennyi_lesz);
                            CMD_UPDATE_mennyiseg.Parameters.Add("@idhely", MySqlDbType.Int32).Value = Convert.ToInt32(helyID);

                            CMD_INSERT_karb.Parameters.Add("@karb_gepid", MySqlDbType.Int32).Value = Convert.ToInt32(gepID);
                            CMD_INSERT_karb.Parameters.Add("@karb_cikkid", MySqlDbType.Int32).Value = Convert.ToInt32(cikkID);
                            CMD_INSERT_karb.Parameters.Add("@karb_mennyi", MySqlDbType.Int32).Value = Convert.ToInt32(int_mennyi);
                            CMD_INSERT_karb.Parameters.Add("@karb_mikor", MySqlDbType.Date).Value = DateTime.Now.Date;

                            if (CMD_UPDATE_mennyiseg.ExecuteNonQuery() > 0 && CMD_INSERT_karb.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Sikeres kiírás!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a kiírás!");
                            }
                        }

                        mysqlcon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Töltse ki az üres mezőket!");
                }
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }

        }

        private void Kiiras_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }

        private void cikknev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(cikknev_combo.Text))
            {
                ComboBoxKezelo.Gyartoi_Cikknevbol(cikknev_combo, gyartoi_combo);
                ComboBoxKezelo.ComboBoxSpecialisFeltoltes(epulet_combo,raktar_combo,oszlop_combo,polc_combo,box_combo,cikknev_combo,gyartoi_combo);
                downarrow.Visible = true;
            }
        }

        private void gyartoi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(gyartoi_combo.Text))
            {
                ComboBoxKezelo.Cikknev_GyartoiSzambol(cikknev_combo, gyartoi_combo);
                ComboBoxKezelo.ComboBoxSpecialisFeltoltes(epulet_combo,raktar_combo,oszlop_combo,polc_combo,box_combo,cikknev_combo,gyartoi_combo);
                downarrow.Visible = true;
            }
        }

        private void gepnev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(gepnev_combo.Text))
            {
                ComboBoxKezelo.Azonosito_Gepnevbol(gepnev_combo, azonosito_combo);
            }
        }

        private void azonosito_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(azonosito_combo.Text))
            {
                ComboBoxKezelo.Gepnev_Azonositobol(gepnev_combo, azonosito_combo);
            }
        }

        private void epulet_combo_TextChanged_1(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Epulet_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }
        private void raktar_combo_TextChanged_1(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Raktar_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }
        private void oszlop_combo_TextChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Oszlop_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }
        private void polc_combo_TextChanged_1(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Polc_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }
    }

}

