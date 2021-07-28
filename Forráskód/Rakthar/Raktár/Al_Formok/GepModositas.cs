using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Raktár.Al_Formok
{
    public partial class GepModositas : Form
    {
        public GepModositas()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
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

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DT_SELECT_gep = new DataTable();

                string QUERY_SELECT_gep = "Select * From gepek Where Gépnév= @gepnev And Azonosítószám= @azonosito";
                string QUERY_UPDATE_gep = "UPDATE gepek SET Gépnév=@upd_gepnev, Azonosítószám=@upd_azonosito Where Gépnév= @select_gepnev And Azonosítószám= @select_azonosito";

                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                using (MySqlCommand CMD_SELECT_gep = new MySqlCommand(QUERY_SELECT_gep, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_gep = new MySqlDataAdapter(CMD_SELECT_gep))
                {
                    mysqlcon.Open();

                    CMD_SELECT_gep.Parameters.Add("@gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                    CMD_SELECT_gep.Parameters.Add("@azonosito", MySqlDbType.String).Value = azonosito_combo.Text;

                    SDA_SELECT_gep.Fill(DT_SELECT_gep);

                    bool gepnev = DT_SELECT_gep.AsEnumerable().Any(row => gepnev_combo.Text == row.Field<String>("Gépnév"));
                    bool azonosito = DT_SELECT_gep.AsEnumerable().Any(row => azonosito_combo.Text == row.Field<String>("Azonosítószám"));

                    if (gepnev && azonosito)
                    {
                        using (MySqlCommand CMD_UPDATE_gep = new MySqlCommand(QUERY_UPDATE_gep, mysqlcon))
                        {
                            CMD_UPDATE_gep.Parameters.Add("@upd_gepnev", MySqlDbType.String).Value = mire_gepnev_txt.Text;
                            CMD_UPDATE_gep.Parameters.Add("@upd_azonosito", MySqlDbType.String).Value = mire_azon_txt.Text;
                            CMD_UPDATE_gep.Parameters.Add("@select_gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                            CMD_UPDATE_gep.Parameters.Add("@select_azonosito", MySqlDbType.String).Value = azonosito_combo.Text;

                            if(CMD_UPDATE_gep.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres módosítás!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a módosítás!");
                            }
                        }
                    }
                    else if(!gepnev || !azonosito)
                    {
                        MessageBox.Show("Nincs ilyen gép!");
                    }
                    mysqlcon.Close();
                }
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }
    }
}
