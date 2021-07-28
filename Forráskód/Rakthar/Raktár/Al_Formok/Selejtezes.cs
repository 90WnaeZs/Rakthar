using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Selejtezes : Form
    {
        string error = "";
        bool van_annyi = false;
        public Selejtezes()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);

            indok_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            indok_combo.Items.Add("Hibás adatbevitel");
            indok_combo.Items.Add("Mást használnak helyette");
            indok_combo.Items.Add("Nincs meg");
            indok_combo.Items.Add("Selejt");
        }
        private void selejt_Btn_Click_1(object sender, EventArgs e)
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

                    string QUERY_cikkID = "Select * From cikk Where Cikknév= @cikknev And Gyártói= @gyartoi";
                    string QUERY_SELECT_mennyiseg = "SELECT * FROM hely WHERE Cikk_ID=@cikkid AND Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc AND Box=@box";
                    string QUERY_UPDATE_mennyiseg = "UPDATE hely SET Mennyiség=@mennyi_lesz WHERE ID_Hely=@idhely";
                    string QUERY_INSERT_selejtezes = "INSERT INTO selejtezes(Cikk_ID,Hely_ID,Mennyiség,Dátum,Indok) values (@selejt_cikkid,@selejt_helyid,@selejt_mennyiseg,@selejt_datum,@selejt_indok)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_cikkID = new MySqlCommand(QUERY_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_cikkID = new MySqlDataAdapter(CMD_cikkID))
                    using (MySqlCommand CMD_mennyiseg = new MySqlCommand(QUERY_SELECT_mennyiseg, mysqlcon))
                    using (MySqlDataAdapter SDA_mennyiseg = new MySqlDataAdapter(CMD_mennyiseg))
                    using (MySqlCommand CMD_UPDATE_mennyiseg = new MySqlCommand(QUERY_UPDATE_mennyiseg, mysqlcon))
                    using (MySqlCommand CMD_INSERT_selejtezes = new MySqlCommand(QUERY_INSERT_selejtezes, mysqlcon))
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

                        if (int_mennyi_van >= 0 && ((int_mennyi_van - int_mennyi) >= 0))  // SZÁMOLÁS, HOGY MENNYI LESZ BELŐLE
                        {
                            van_annyi = true;
                            int_mennyi_lesz = int_mennyi_van - int_mennyi;
                        }
                        else if (int_mennyi_van < int_mennyi)
                        {
                            van_annyi = false;
                            error += "Nincs ennyi belőle!" + Environment.NewLine;
                        }

                        // HELY ID
                        DataRow helyID_row;
                        string helyID = "";
                        if (mennyiseg_dt != null && mennyiseg_dt.Rows.Count > 0)
                        {
                            helyID_row = mennyiseg_dt.Rows[0];
                            helyID = helyID_row["ID_Hely"].ToString();
                        }

                        // MENNYISÉG BEVITELE
                        if (van_annyi)
                        {
                            CMD_UPDATE_mennyiseg.Parameters.Add("@mennyi_lesz", MySqlDbType.Int32).Value = Convert.ToInt32(int_mennyi_lesz);
                            CMD_UPDATE_mennyiseg.Parameters.Add("@idhely", MySqlDbType.Int32).Value = Convert.ToInt32(helyID);

                            CMD_INSERT_selejtezes.Parameters.Add("@selejt_cikkid", MySqlDbType.Int32).Value = Convert.ToInt32(cikkID);
                            CMD_INSERT_selejtezes.Parameters.Add("@selejt_helyid", MySqlDbType.Int32).Value = Convert.ToInt32(helyID);
                            CMD_INSERT_selejtezes.Parameters.Add("@selejt_mennyiseg", MySqlDbType.Int32).Value = Convert.ToInt32(mennyit_num.Text);
                            CMD_INSERT_selejtezes.Parameters.Add("@selejt_datum", MySqlDbType.Date).Value = DateTime.Now.Date;
                            CMD_INSERT_selejtezes.Parameters.Add("@selejt_indok", MySqlDbType.String).Value = indok_combo.Text;

                            if (CMD_UPDATE_mennyiseg.ExecuteNonQuery() > 0 && CMD_INSERT_selejtezes.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Sikeres selejtezés!");
                            }
                            else
                            {
                                error += "Nem sikerült a bevételezés!" + Environment.NewLine;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(error))
                        {
                            MessageBox.Show(error, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            error = "";
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

        private void Selejtezes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }

        private void cikknev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(cikknev_combo.Text))
            {
                downarrow.Visible = true;
                ComboBoxKezelo.Gyartoi_Cikknevbol(cikknev_combo, gyartoi_combo);
                ComboBoxKezelo.ComboBoxSpecialisFeltoltes(epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo, cikknev_combo, gyartoi_combo);
            }
        }

        private void gyartoi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(gyartoi_combo.Text))
            {
                downarrow.Visible = true;
                ComboBoxKezelo.Cikknev_GyartoiSzambol(cikknev_combo, gyartoi_combo);
                ComboBoxKezelo.ComboBoxSpecialisFeltoltes(epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo, cikknev_combo, gyartoi_combo);
            }
        }

        private void epulet_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Epulet_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }

        private void raktar_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Raktar_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }

        private void oszlop_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Oszlop_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }

        private void polc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.ClearComboBoxItems(this);
            ComboBoxKezelo.Polc_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
        }
    }
}
