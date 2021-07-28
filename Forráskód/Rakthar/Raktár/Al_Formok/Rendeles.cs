using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Rendeles : Form
    {
        string error = "";
        public Rendeles()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
            {
                mysqlcon.Open();
                MySqlCommand comm = new MySqlCommand("Select Cikknév From cikk", mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    cikknev_combo.Items.Add(reader.GetString("Cikknév"));
                }
                reader.Close();

                MySqlCommand comm2 = new MySqlCommand("Select Beszállító_név From beszallito", mysqlcon);
                MySqlDataReader reader2 = comm2.ExecuteReader();
                while (reader2.Read())
                {
                    beszallito_combo.Items.Add(reader2.GetString("Beszállító_név"));
                }
                reader2.Close();

                mysqlcon.Close();
            }
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    string str_cikkID = "";
                    string str_beszID = "";
                    //string ma = DateTime.Now.ToString("yyyy-MM-dd");

                    DataTable DT_SELECT_cikkID = new DataTable();
                    DataTable DT_SELECT_beszID = new DataTable();

                    string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev";
                    string QUERY_SELECT_beszID = "SELECT ID_Beszállító FROM beszallito WHERE Beszállító_név=@besz_nev";
                    string QUERY_INSERT_rendeles = "INSERT INTO rendeles (Cikk_ID,Beszállító_ID,Mennyiség,Rendelve,Érkezés) values (@ins_cikkID,@ins_beszID,@ins_mennyiseg,@ins_rendelve,@ins_erkezes)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                    using (MySqlCommand CMD_SELECT_beszID = new MySqlCommand(QUERY_SELECT_beszID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_beszID = new MySqlDataAdapter(CMD_SELECT_beszID))
                    using (MySqlCommand CMD_INSERT_rendeles = new MySqlCommand(QUERY_INSERT_rendeles, mysqlcon))
                    {
                        mysqlcon.Open();

                        CMD_SELECT_cikkID.Parameters.Add("@cikknev",MySqlDbType.String).Value = cikknev_combo.Text;
                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            str_cikkID = DT_SELECT_cikkID.Rows[0]["ID_Cikk"].ToString();
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            error += "Nincs ilyen cikk!" + Environment.NewLine;
                        }

                        CMD_SELECT_beszID.Parameters.Add("@besz_nev", MySqlDbType.String).Value = beszallito_combo.Text;
                        SDA_SELECT_beszID.Fill(DT_SELECT_beszID);

                        if (DT_SELECT_beszID != null && DT_SELECT_beszID.Rows.Count > 0)
                        {
                            str_beszID = DT_SELECT_beszID.Rows[0]["ID_Beszállító"].ToString();
                        }
                        else if (DT_SELECT_beszID != null && DT_SELECT_beszID.Rows.Count == 0)
                        {
                            error += "Nincs ilyen beszállító!" + Environment.NewLine;
                        }

                        if(!String.IsNullOrWhiteSpace(str_cikkID) && !String.IsNullOrWhiteSpace(str_cikkID))
                        {
                            CMD_INSERT_rendeles.Parameters.Add("@ins_cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                            CMD_INSERT_rendeles.Parameters.Add("@ins_beszID", MySqlDbType.Int32).Value = Convert.ToInt32(str_beszID);
                            CMD_INSERT_rendeles.Parameters.Add("@ins_mennyiseg", MySqlDbType.Int32).Value = Convert.ToInt32(mennyit_num.Text);
                            CMD_INSERT_rendeles.Parameters.Add("@ins_rendelve", MySqlDbType.Date).Value = DateTime.Now.Date;
                            CMD_INSERT_rendeles.Parameters.Add("@ins_erkezes", MySqlDbType.Date).Value = this.dateTimePicker1.Value.Date;

                            if (CMD_INSERT_rendeles.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres mentés!");
                            }
                            else
                            {
                                error += "Nem sikerült rögzíteni!" + Environment.NewLine;
                            }
                            mysqlcon.Close();
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(error))
                    {
                        MessageBox.Show(error, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        error = "";
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
    }
}
