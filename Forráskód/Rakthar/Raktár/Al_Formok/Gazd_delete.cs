using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;

namespace Raktár
{
    public partial class Gazd_delete : Form
    {
        public Gazd_delete()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
            beszallito_combo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void delete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(!String.IsNullOrWhiteSpace(beszallito_combo.Text))
                {
                    string QUERY_SELECT_beszallito = "SELECT Beszállító_név FROM beszallito WHERE Beszállító_név=@besz_nev";
                    string QUERY_DELETE_beszallito = "DELETE FROM beszallito WHERE Beszállító_név=@besz_nev";

                    DataTable DT_SELECT_beszallito = new DataTable();

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_beszallito = new MySqlCommand(QUERY_SELECT_beszallito,mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_beszallito = new MySqlDataAdapter(CMD_SELECT_beszallito))
                    using (MySqlCommand CMD_DELETE_beszallito = new MySqlCommand(QUERY_DELETE_beszallito, mysqlcon))
                    {
                        mysqlcon.Open();

                        CMD_SELECT_beszallito.Parameters.Add("@besz_nev",MySqlDbType.String).Value = beszallito_combo.Text;
                        SDA_SELECT_beszallito.Fill(DT_SELECT_beszallito);

                        bool check = DT_SELECT_beszallito.AsEnumerable().Any(row => beszallito_combo.Text == row.Field<String>("Beszállító_név"));

                        if(check)
                        {
                            CMD_DELETE_beszallito.Parameters.Add("@besz_nev", MySqlDbType.String).Value = beszallito_combo.Text;

                            if (CMD_DELETE_beszallito.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres törlés!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a törlés!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nincs ilyen beszállító!");
                        }
                        mysqlcon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Írja be a beszállító nevét!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
