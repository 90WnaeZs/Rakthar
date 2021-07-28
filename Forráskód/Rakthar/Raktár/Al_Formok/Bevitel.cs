using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Betarolas : Form
    {
        string error = "";
        int mennyi_lesz = 0;
        string cikkID;
        string helyID;
        string mennyi_van;

        bool cikk_van = false;
        bool hely_van = false;

        public Betarolas()
        {
            InitializeComponent();
            cikkID = "";
            helyID = "";
            mennyi_van = "";
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }
        
        
        private void Bevetel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DT_SELECT_cikk = new DataTable();
                DataTable DT_SELECT_cikkID = new DataTable();
                DataTable DT_SELECT_helyID = new DataTable();
                DataTable DT_SELECT_mennyi = new DataTable();

                string QUERY_SELECT_cikk = "SELECT * FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev";
                string QUERY_SELECT_helyID = "SELECT ID_Hely FROM hely WHERE Cikk_ID=@cikkID AND Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc AND Box=@box";
                string QUERY_SELECT_mennyiseg = "SELECT Mennyiség FROM hely WHERE ID_Hely=@idhely";
                
                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                using (MySqlCommand CMD_SELECT_cikk = new MySqlCommand(QUERY_SELECT_cikk, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_cikk = new MySqlDataAdapter(CMD_SELECT_cikk))
                using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                using (MySqlCommand CMD_SELECT_helyID = new MySqlCommand(QUERY_SELECT_helyID, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_helyID = new MySqlDataAdapter(CMD_SELECT_helyID))
                {
                    mysqlcon.Open();

                    CMD_SELECT_cikk.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                    CMD_SELECT_cikk.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;
                    SDA_SELECT_cikk.Fill(DT_SELECT_cikk);

                    if (DT_SELECT_cikk != null && DT_SELECT_cikk.Rows.Count > 0)
                    {
                        cikk_van = true;
                    }
                    else if (DT_SELECT_cikk != null && DT_SELECT_cikk.Rows.Count == 0)
                    {
                        cikk_van = false;
                        error += "Nincs ilyen cikk! Rosszul adta meg a cikknevet, vagy gyártóit!" + Environment.NewLine;
                    }

                    if (cikk_van)
                    {
                        CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                            cikkID = cikkID_row["ID_Cikk"].ToString();
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            error += "Nincs ilyen cikk!" + Environment.NewLine;
                        }

                        if (cikk_van)
                        {
                            CMD_SELECT_helyID.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(cikkID);
                            CMD_SELECT_helyID.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_SELECT_helyID.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar_combo.Text);
                            CMD_SELECT_helyID.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop_combo.Text);
                            CMD_SELECT_helyID.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc_combo.Text);
                            CMD_SELECT_helyID.Parameters.Add("@box", MySqlDbType.Int32).Value = Convert.ToInt32(box_combo.Text);

                            SDA_SELECT_helyID.Fill(DT_SELECT_helyID);

                            if (DT_SELECT_helyID != null && DT_SELECT_helyID.Rows.Count > 0)
                            {
                                hely_van = true;
                                DataRow helyID_row = DT_SELECT_helyID.Rows[0];
                                helyID = helyID_row["ID_Hely"].ToString();
                            }
                            else if (DT_SELECT_helyID != null && DT_SELECT_helyID.Rows.Count == 0)
                            {
                                hely_van = false;
                            }

                        }
                    }
                }
                if (!FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    error += "Töltse ki az üres mezőket!" + Environment.NewLine;
                }

                else if (korabbi_RB.Checked && FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    if (cikk_van && hely_van && mennyi_num.Value>0)
                    {
                        string QUERY_UPDATE_hely = "UPDATE hely SET Mennyiség=@upd_mennyi_lesz WHERE ID_Hely=@upd_idhely";

                        using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                        using (MySqlCommand CMD_UPDATE_hely = new MySqlCommand(QUERY_UPDATE_hely, mysqlcon))
                        using (MySqlCommand CMD_SELECT_mennyi = new MySqlCommand(QUERY_SELECT_mennyiseg, mysqlcon))
                        using (MySqlDataAdapter SDA_SELECT_mennyi = new MySqlDataAdapter(CMD_SELECT_mennyi))
                        {
                            mysqlcon.Open();

                            CMD_SELECT_mennyi.Parameters.Add("@idhely", MySqlDbType.Int32).Value = Convert.ToInt32(helyID);
                            SDA_SELECT_mennyi.Fill(DT_SELECT_mennyi);

                            if (DT_SELECT_mennyi != null && DT_SELECT_mennyi.Rows.Count > 0)
                            {
                                DataRow mennyi_row = DT_SELECT_mennyi.Rows[0];
                                mennyi_van = mennyi_row["Mennyiség"].ToString();
                            }
                            else if (DT_SELECT_mennyi != null && DT_SELECT_mennyi.Rows.Count == 0)
                            {
                                error += "Nincs ilyen helyen ilyen cikk!" + Environment.NewLine;
                            }
                            mennyi_lesz = Convert.ToInt32(mennyi_van) + Convert.ToInt32(mennyi_num.Value);

                            CMD_UPDATE_hely.Parameters.Add("@upd_mennyi_lesz", MySqlDbType.Int32).Value = Convert.ToInt32(mennyi_lesz);
                            CMD_UPDATE_hely.Parameters.Add("@upd_idhely", MySqlDbType.Int32).Value = Convert.ToInt32(helyID);

                            if(CMD_UPDATE_hely.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres bevételezés!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a bevételezés!");
                            }

                            
                        }
                    }
                    else if(cikk_van && hely_van && mennyi_num.Value == 0)
                    {
                        error += "A mennyiség nem lehet nulla!" + Environment.NewLine;
                    }
                }

                else if (ujhely_RB.Checked)
                {
                    if (cikk_van && !hely_van)
                    {
                        string QUERY_INSERT_hely = "INSERT INTO hely (Cikk_ID, Mennyiség, Épület, Raktár, Oszlop, Polc, Box) values (@cikkID,@mennyiseg,@epulet,@raktar,@oszlop,@polc,@box)";

                        using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                        using (MySqlCommand CMD_INSERT_hely = new MySqlCommand(QUERY_INSERT_hely, mysqlcon))
                        {
                            mysqlcon.Open();

                            CMD_INSERT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(cikkID);
                            CMD_INSERT_hely.Parameters.Add("@mennyiseg", MySqlDbType.Int32).Value = Convert.ToInt32(mennyi_num.Text);
                            CMD_INSERT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@box", MySqlDbType.Int32).Value = Convert.ToInt32(box_combo.Text);

                            MySqlDataReader READER_INSERT_hely;
                            READER_INSERT_hely = CMD_INSERT_hely.ExecuteReader();

                            READER_INSERT_hely.Close();
                            MessageBox.Show("Sikeres bevételezés!");
                        }
                    }
                    else if (cikk_van && !hely_van && mennyi_num.Value == 0)
                    {
                        error += "A mennyiség nem lehet nulla!" + Environment.NewLine;
                    }
                    else if (hely_van)
                    {
                        error += "Erre a helyre már van tárolva ez a cikk!" + Environment.NewLine;
                    }
                }
                if (!String.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show(error, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    error = "";
                }
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }

        private void cikkNev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(cikknev_combo.Text))
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
        
        private void epulet_combo_TextChanged(object sender, EventArgs e)
        {
            if(korabbi_RB.Checked)
            {
                ComboBoxKezelo.ClearComboBoxItems(this);
                ComboBoxKezelo.Epulet_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
            }
        }

        private void raktar_combo_TextChanged(object sender, EventArgs e)
        {
            if (korabbi_RB.Checked)
            {
                ComboBoxKezelo.ClearComboBoxItems(this);
                ComboBoxKezelo.Raktar_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
            }
        }

        private void oszlop_combo_TextChanged(object sender, EventArgs e)
        {
            if (korabbi_RB.Checked)
            {
                ComboBoxKezelo.ClearComboBoxItems(this);
                ComboBoxKezelo.Oszlop_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
            }
        }

        private void polc_combo_TextChanged(object sender, EventArgs e)
        {
            if (korabbi_RB.Checked)
            {
                ComboBoxKezelo.ClearComboBoxItems(this);
                ComboBoxKezelo.Polc_Szures(cikknev_combo, gyartoi_combo, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
            }
        }

        private void korabbi_RB_CheckedChanged(object sender, EventArgs e)
        {
            downarrow.Visible = true;
            epulet_combo.Items.Clear();
            raktar_combo.Items.Clear();
            oszlop_combo.Items.Clear();
            polc_combo.Items.Clear();
            box_combo.Items.Clear();

            bool van_cikk = false;

            string str_cikkID = "";

            DataTable DT_SELECT_cikkID = new DataTable();

            string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
            string QUERY_SELECT_hely = "SELECT Épület,Raktár,Oszlop,Polc,Box FROM hely WHERE Cikk_ID=@cikkID";
            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
            using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
            using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
            using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
            using (MySqlDataAdapter SDA_SELECT_hely = new MySqlDataAdapter(CMD_SELECT_hely))
            {
                mysqlcon.Open();
                CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;

                SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                {
                    DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                    str_cikkID = cikkID_row["ID_Cikk"].ToString();
                    van_cikk = true;

                    if (van_cikk)
                    {
                        CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                        MySqlDataReader READER_SELECT_hely = CMD_SELECT_hely.ExecuteReader();

                        while (READER_SELECT_hely.Read())
                        {
                            ComboBoxKezelo.ComboBoxSzűrtHelyFeltöltés(READER_SELECT_hely, epulet_combo, raktar_combo, oszlop_combo, polc_combo, box_combo);
                        }
                        READER_SELECT_hely.Close();
                    }
                }
                else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                {
                    van_cikk = false;
                    MessageBox.Show("Nincs ilyen cikk!");
                }
            }

        }

        private void ujhely_RB_CheckedChanged(object sender, EventArgs e)
        {
            downarrow.Visible = false;
            ComboBoxKezelo.ClearComboBoxItems(this);

            epulet_combo.Items.Add("1");
            epulet_combo.Items.Add("2");
            epulet_combo.Items.Add("3");
            raktar_combo.Items.Add("1");
            raktar_combo.Items.Add("2");
            for (int i = 1; i < 41; i++)
            {
                oszlop_combo.Items.Add(i.ToString());
            }
            for (int i = 1; i < 7; i++)
            {
                polc_combo.Items.Add(i.ToString());
            }
            for (int i = 1; i < 7; i++)
            {
                box_combo.Items.Add(i.ToString());
            }

        }

        private void Bevitel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
