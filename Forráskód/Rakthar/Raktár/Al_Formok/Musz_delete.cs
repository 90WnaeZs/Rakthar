using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Musz_delete : Form
    {
        public Musz_delete()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }

        private void delete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    DataTable sel_dt = new DataTable();

                    string select_sql = "Select * From gepek Where Gépnév= @gepnev And Azonosítószám= @azonosito";
                    string delete_sql = "DELETE FROM gepek Where Gépnév= @del_gepnev And Azonosítószám= @del_azonosito";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand cmd = new MySqlCommand(select_sql, mysqlcon))
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        mysqlcon.Open();

                        cmd.Parameters.Add("@gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                        cmd.Parameters.Add("@azonosito", MySqlDbType.String).Value = azonosito_combo.Text;

                        sda.Fill(sel_dt);

                        bool gepnev = sel_dt.AsEnumerable().Any(row => gepnev_combo.Text == row.Field<String>("Gépnév"));
                        bool azonosito = sel_dt.AsEnumerable().Any(row => azonosito_combo.Text == row.Field<String>("Azonosítószám"));

                        if (gepnev && azonosito)
                        {
                            using (MySqlConnection del_mysqlcon = new MySqlConnection(Ipcim.constr))
                            using (MySqlCommand del_cmd = new MySqlCommand(delete_sql, del_mysqlcon))
                            {
                                del_cmd.Parameters.Add("@del_gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                                del_cmd.Parameters.Add("@del_azonosito", MySqlDbType.String).Value = azonosito_combo.Text;

                                if (del_cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Sikeres törlés!");
                                }
                                else
                                {
                                    MessageBox.Show("Nem sikerült a törlés!");
                                }
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

        private void gepnev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Azonosito_Gepnevbol(gepnev_combo, azonosito_combo);
        }

        private void azonosito_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Gepnev_Azonositobol(gepnev_combo, azonosito_combo);
        }
    }
}
