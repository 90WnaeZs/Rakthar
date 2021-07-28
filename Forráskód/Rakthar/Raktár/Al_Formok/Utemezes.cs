using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Utemezes : Form
    {
        public Utemezes()
        {
            InitializeComponent();
            datum.MinDate = DateTime.Now;
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }
        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    DataTable sel_dt = new DataTable();

                    DateTime date = new DateTime();
                    date = datum.Value;
                    TimeSpan time = new TimeSpan();
                    time = ora.Value.TimeOfDay;
                    string select_sql = "Select * From gepek Where Gépnév= @gepnev And Azonosítószám= @azonosito";
                    string insert_sql = "INSERT INTO utemezes (Gép_ID,Dátum,Óra) values(@idgep,@datum,@ora)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand select_utem_cmd = new MySqlCommand(select_sql, mysqlcon))
                    using (MySqlDataAdapter select_utem_sda = new MySqlDataAdapter(select_utem_cmd))
                    {
                        mysqlcon.Open();
                        select_utem_cmd.Parameters.Add("@gepnev", MySqlDbType.String).Value = gepnev_combo.Text;
                        select_utem_cmd.Parameters.Add("@azonosito", MySqlDbType.String).Value = azonosito_combo.Text;

                        select_utem_sda.Fill(sel_dt);

                        bool gepnev = sel_dt.AsEnumerable().Any(row => gepnev_combo.Text == row.Field<String>("Gépnév"));
                        bool azonosito = sel_dt.AsEnumerable().Any(row => azonosito_combo.Text == row.Field<String>("Azonosítószám"));

                        DataRow id_gep_row = sel_dt.Rows[0];
                        string id_gep = id_gep_row["ID_Gép"].ToString();
                        int int_id_gep = Convert.ToInt32(id_gep);

                        if (gepnev && azonosito)
                        {
                            using (MySqlCommand insert_utem_cmd = new MySqlCommand(insert_sql, mysqlcon))
                            {
                                insert_utem_cmd.Parameters.Add("@idgep", MySqlDbType.Int32).Value = int_id_gep;
                                insert_utem_cmd.Parameters.Add("@datum", MySqlDbType.Date).Value = datum.Value.Date;
                                insert_utem_cmd.Parameters.AddWithValue("@ora", time);

                                if (insert_utem_cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Időpont felvéve!");
                                }
                                else
                                {
                                    MessageBox.Show("Az időpont felvétele nem sikerült!");
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

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }
        private void azonosito_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Gepnev_Azonositobol(gepnev_combo, azonosito_combo);
        }

        private void gepnev_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKezelo.Azonosito_Gepnevbol(gepnev_combo, azonosito_combo);
        }
    }
    }

