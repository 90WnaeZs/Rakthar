using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Cikkmod : Form
    {
        string error = "";
        public Cikkmod()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }

        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    DataTable DT_select_cikkID = new DataTable();
                    DataTable DT_select_beszID = new DataTable();
                    DataTable DT_select_egysID = new DataTable();

                    string str_cikkID = "";
                    string str_beszID = "";
                    string str_egysID = "";

                    string SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév = @cikknev AND Gyártói = @gyartoi";

                    string SELECT_beszallitoID = "SELECT ID_Beszállító FROM beszallito WHERE Beszállító_név=@beszallitonev";
                    string SELECT_egysegID = "SELECT ID_Mennyiség FROM mennyiseg WHERE Megnevezés=@egyseg";

                    string UPDATE_cikk_adatok = "UPDATE cikk SET Cikknév=@upd_cikknev, Gyártói=@upd_gyartoi, Típus=@tipus, Beszállító_ID=@beszid, Ár=@ar, Mennyiség_ID=@egysegid, Minimum=@min, Maximum=@max WHERE ID_Cikk=@upd_cikkID";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_select_cikkID = new MySqlCommand(SELECT_cikkID, mysqlcon))
                    using (MySqlCommand CMD_select_beszID = new MySqlCommand(SELECT_beszallitoID, mysqlcon))
                    using (MySqlCommand CMD_select_egysID = new MySqlCommand(SELECT_egysegID, mysqlcon))
                    using (MySqlCommand CMD_UPDATE_cikk = new MySqlCommand(UPDATE_cikk_adatok, mysqlcon))
                    using (MySqlDataAdapter SDA_select_cikkID = new MySqlDataAdapter(CMD_select_cikkID))
                    using (MySqlDataAdapter SDA_select_beszID = new MySqlDataAdapter(CMD_select_beszID))
                    using (MySqlDataAdapter SDA_select_egysID = new MySqlDataAdapter(CMD_select_egysID))
                    {
                        mysqlcon.Open();

                        CMD_select_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                        CMD_select_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;
                        SDA_select_cikkID.Fill(DT_select_cikkID);
                        foreach (DataRow row in DT_select_cikkID.Rows)
                        {
                            str_cikkID = row["ID_Cikk"].ToString();
                        }

                        CMD_select_beszID.Parameters.Add("@beszallitonev", MySqlDbType.String).Value = beszallito_combo.Text;
                        SDA_select_beszID.Fill(DT_select_beszID);
                        foreach (DataRow row in DT_select_beszID.Rows)
                        {
                            str_beszID = row["ID_Beszállító"].ToString();
                        }

                        CMD_select_egysID.Parameters.Add("@egyseg", MySqlDbType.String).Value = egyseg_combo.Text;
                        SDA_select_egysID.Fill(DT_select_egysID);
                        foreach (DataRow row in DT_select_egysID.Rows)
                        {
                            str_egysID = row["ID_Mennyiség"].ToString();
                        }

                        if (!String.IsNullOrEmpty(str_cikkID))
                        {
                            CMD_UPDATE_cikk.Parameters.Add("@upd_cikknev", MySqlDbType.String).Value = ujcikknev_txt.Text;
                            CMD_UPDATE_cikk.Parameters.Add("@upd_gyartoi", MySqlDbType.String).Value = ujgyartoi_txt.Text;
                            CMD_UPDATE_cikk.Parameters.Add("@tipus", MySqlDbType.String).Value = tipus_combo.Text;

                            CMD_UPDATE_cikk.Parameters.Add("@beszid", MySqlDbType.Int32).Value = Convert.ToInt32(str_beszID);
                            CMD_UPDATE_cikk.Parameters.Add("@ar", MySqlDbType.Int32).Value = Convert.ToInt32(ar_num.Text);
                            CMD_UPDATE_cikk.Parameters.Add("@egysegid", MySqlDbType.Int32).Value = Convert.ToInt32(str_egysID);
                            CMD_UPDATE_cikk.Parameters.Add("@min", MySqlDbType.Int32).Value = Convert.ToInt32(min_num.Text);
                            CMD_UPDATE_cikk.Parameters.Add("@max", MySqlDbType.Int32).Value = Convert.ToInt32(max_num.Text);
                            CMD_UPDATE_cikk.Parameters.Add("@upd_cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);

                            if(CMD_UPDATE_cikk.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres módosítás!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a módosítás!");
                            }
                            
                        }
                        else if(String.IsNullOrEmpty(str_cikkID))
                        {
                            error += "Nincs ilyen cikk!" + Environment.NewLine;
                        }
                    }
                }
                else if(!FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    error += "Töltse ki az üres mezőket!" + Environment.NewLine;
                }
                if(!String.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show(error);
                    error = "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }
        private void betoltes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DT_select_cikk = new DataTable();
                string SELECT_cikk_adatok = Adatbazis.cikk_query+ "WHERE Cikknév = @cikknev AND Gyártói = @gyartoi";

                using (MySqlConnection CON_select_cikk=new MySqlConnection(Ipcim.constr))
                using (MySqlCommand CMD_select_cikk = new MySqlCommand(SELECT_cikk_adatok,CON_select_cikk))
                using (MySqlDataAdapter SDA_select_cikk=new MySqlDataAdapter(CMD_select_cikk))
                {
                    CON_select_cikk.Open();

                    CMD_select_cikk.Parameters.Add("@cikknev", MySqlDbType.String).Value=cikknev_combo.Text;
                    CMD_select_cikk.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;

                    SDA_select_cikk.Fill(DT_select_cikk);

                    if(DT_select_cikk!=null && DT_select_cikk.Rows.Count>0)
                    {
                        foreach (DataRow row in DT_select_cikk.Rows)
                        {
                            ujcikknev_txt.Text = row["Cikknév"].ToString();
                            ujgyartoi_txt.Text = row["Gyártói"].ToString();
                            tipus_combo.Text = row["Típus"].ToString();
                            beszallito_combo.Text = row["Beszállító"].ToString();
                            ar_num.Text = row["Ár_Forint"].ToString(); //Ár_Forint
                            egyseg_combo.Text = row["Egység"].ToString();
                            min_num.Text = row["Minimum"].ToString();
                            max_num.Text = row["Maximum"].ToString();
                        }
                    }
                    else if(DT_select_cikk != null && DT_select_cikk.Rows.Count == 0)
                    {
                        MessageBox.Show("Nincs ilyen cikk!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cikknev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(cikknev_combo.Text))
            {
                ComboBoxKezelo.Gyartoi_Cikknevbol(cikknev_combo, gyartoi_combo);
            }
        }

        private void gyartoi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(gyartoi_combo.Text))
            {
                ComboBoxKezelo.Cikknev_GyartoiSzambol(cikknev_combo, gyartoi_combo);
            }
        }
    }
}
