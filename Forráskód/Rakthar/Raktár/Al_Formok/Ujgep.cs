using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;

namespace Raktár
{
    public partial class Ujgep : Form
    {
        bool ures = false;
        public Ujgep()
        {
            InitializeComponent();
        }
        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(gepnev_txtbox.Text) || String.IsNullOrWhiteSpace(azonosito_txtbox.Text))
                {
                    ures = true;
                    MessageBox.Show("Hiányos adatok!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!String.IsNullOrWhiteSpace(gepnev_txtbox.Text) && !String.IsNullOrWhiteSpace(azonosito_txtbox.Text))
                {
                    ures = false;
                }
                if (!ures)
                {
                    DataTable sel_dt = new DataTable();

                    string select_gep = "SELECT * FROM gepek WHERE Gépnév=@gepnev AND Azonosítószám=@azonosito";
                    string insert_gep = "INSERT INTO gepek (Gépnév,Azonosítószám) values (@ins_gepnev,@ins_azonosito)";

                    using (MySqlConnection select_con = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand select_cmd = new MySqlCommand(select_gep, select_con))
                    using (MySqlDataAdapter select_sda = new MySqlDataAdapter(select_cmd))
                    {
                        select_con.Open();
                        select_cmd.Parameters.Add("@gepnev", MySqlDbType.String).Value = gepnev_txtbox.Text;
                        select_cmd.Parameters.Add("@azonosito", MySqlDbType.String).Value = azonosito_txtbox.Text;

                        select_sda.Fill(sel_dt);
                        
                        if (sel_dt != null && sel_dt.Rows.Count == 0)
                        {
                            using (MySqlConnection insert_con = new MySqlConnection(Ipcim.constr))
                            using (MySqlCommand insert_cmd = new MySqlCommand(insert_gep, insert_con))
                            {
                                insert_con.Open();
                                insert_cmd.Parameters.Add("@ins_gepnev", MySqlDbType.String).Value = gepnev_txtbox.Text;
                                insert_cmd.Parameters.Add("@ins_azonosito", MySqlDbType.String).Value = azonosito_txtbox.Text;

                                if(insert_cmd.ExecuteNonQuery()>0)
                                {
                                    MessageBox.Show("Új gép hozzáadva!");
                                }

                                insert_con.Close();
                            }
                        }
                        else if(sel_dt != null && sel_dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Ez már szerepel az adatbázisban");
                        }
                        select_con.Close();
                    }
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
    }
}
