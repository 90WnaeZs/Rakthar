using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Torles : Form
    {
        string mennyivan = "";
        bool lehet_torolni = true;
        public Torles()
        {
            InitializeComponent();
            try
            {
                string cikk_feltoltes = "SELECT cikk.Cikknév FROM cikk JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID WHERE Mennyiség=0";
                string gyartoi_feltoltes = "SELECT cikk.Gyártói FROM cikk JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID WHERE Mennyiség=0";

                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                using (MySqlCommand cikk_comm = new MySqlCommand(cikk_feltoltes, mysqlcon))
                using (MySqlCommand gyartoi_comm = new MySqlCommand(gyartoi_feltoltes, mysqlcon))
                {
                    mysqlcon.Open();

                    MySqlDataReader cikk_reader = cikk_comm.ExecuteReader();
                    while (cikk_reader.Read())
                    {
                        cikknev_combo.Items.Add(cikk_reader.GetString("Cikknév"));
                    }
                    cikk_reader.Close();

                    MySqlDataReader gyartoi_reader = gyartoi_comm.ExecuteReader();
                    while (gyartoi_reader.Read())
                    {
                        gyartoi_combo.Items.Add(gyartoi_reader.GetString("Gyártói"));
                    }
                    gyartoi_reader.Close();

                    mysqlcon.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void torles_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    {
                        DataTable DT_sel_cikkID = new DataTable();
                        DataTable DT_sel_mennyiseg = new DataTable();

                        string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                        string QUERY_SELECT_mennyiseg = "SELECT Mennyiség FROM hely WHERE Cikk_ID=@cikkid";
                        string QUERY_DELETE_cikk = "DELETE FROM cikk WHERE ID_Cikk=@del_cikkid";

                        using (MySqlConnection CON_cikkID = new MySqlConnection(Ipcim.constr)) // CIKK ID SELECT
                        using (MySqlCommand CMD_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, CON_cikkID))
                        using (MySqlDataAdapter SDA_cikkID = new MySqlDataAdapter(CMD_cikkID))
                        {
                            CON_cikkID.Open();
                            CMD_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_combo.Text;
                            CMD_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_combo.Text;

                            SDA_cikkID.Fill(DT_sel_cikkID);

                            if (DT_sel_cikkID != null && DT_sel_cikkID.Rows.Count > 0)
                            {
                                DataRow ROW_cikkID = DT_sel_cikkID.Rows[0];
                                string STR_cikkID = ROW_cikkID["ID_Cikk"].ToString();

                                using (MySqlConnection CON_mennyiseg = new MySqlConnection(Ipcim.constr)) // MENNYISÉG SELECT
                                using (MySqlCommand CMD_mennyiseg = new MySqlCommand(QUERY_SELECT_mennyiseg, CON_mennyiseg))
                                using (MySqlDataAdapter SDA_mennyiseg = new MySqlDataAdapter(CMD_mennyiseg))
                                {
                                    CON_mennyiseg.Open();
                                    CMD_mennyiseg.Parameters.Add("@cikkid", MySqlDbType.Int32).Value = Convert.ToInt32(STR_cikkID);

                                    SDA_mennyiseg.Fill(DT_sel_mennyiseg);

                                    if (DT_sel_mennyiseg != null && DT_sel_mennyiseg.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in DT_sel_mennyiseg.Rows)
                                        {
                                            mennyivan = row["Mennyiség"].ToString();
                                            if (int.Parse(mennyivan) > 0)
                                            {
                                                lehet_torolni = false;
                                            }
                                        }
                                        if (lehet_torolni)
                                        {
                                            using (MySqlConnection CON_delete = new MySqlConnection(Ipcim.constr))
                                            using (MySqlCommand CMD_delete = new MySqlCommand(QUERY_DELETE_cikk, CON_delete))
                                            {
                                                CON_delete.Open();
                                                CMD_delete.Parameters.Add("@del_cikkid", MySqlDbType.String).Value = STR_cikkID;

                                                if (CMD_delete.ExecuteNonQuery() > 0)
                                                {
                                                    MessageBox.Show("Cikk törölve!");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Nem sikerült a törlés!");
                                                }
                                                CON_delete.Close();
                                            }
                                        }
                                        else if (!lehet_torolni)
                                        {
                                            MessageBox.Show("Nem lehet törölni!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Töltse ki az üres mezőket!");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void cikkNev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Gyartoi_Cikknevbol(cikknev_combo,gyartoi_combo);
        }
        private void gyartoi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Cikknev_GyartoiSzambol(cikknev_combo, gyartoi_combo);
        }
    }
}
