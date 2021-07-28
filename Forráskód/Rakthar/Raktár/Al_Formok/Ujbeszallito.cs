using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Ujbeszallito : Form
    {
        public Ujbeszallito()
        {
            InitializeComponent();
        }
        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FormEllenorzo.Bevitel_ellenorzo(this))
                {
                    DataTable DT_select_besz = new DataTable();

                    string select_beszallito = "SELECT * FROM beszallito WHERE Beszállító_név=@sel_besz_nev";
                    string insert_beszallito = "INSERT INTO beszallito (Beszállító_név,Szállítási_idő,Város,Cím,Telefonszám,Emailcím) VALUES (@besz_nev,@szall_ido,@varos,@cim,@telefon,@email)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_beszallito = new MySqlCommand(select_beszallito, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_beszallito = new MySqlDataAdapter(CMD_SELECT_beszallito))
                    using (MySqlCommand CMD_INSERT_beszallito = new MySqlCommand(insert_beszallito, mysqlcon))
                    using (MySqlDataAdapter SDA_INSERT_beszallito = new MySqlDataAdapter(CMD_INSERT_beszallito))
                    {
                        mysqlcon.Open();

                        CMD_SELECT_beszallito.Parameters.Add("@sel_besz_nev", MySqlDbType.String).Value = besznev_txtbox.Text;
                        SDA_SELECT_beszallito.Fill(DT_select_besz);

                        if(DT_select_besz!=null && DT_select_besz.Rows.Count==0)
                        {
                            CMD_INSERT_beszallito.Parameters.Add("@besz_nev", MySqlDbType.String).Value = besznev_txtbox.Text;
                            CMD_INSERT_beszallito.Parameters.Add("@szall_ido", MySqlDbType.Int32).Value = Convert.ToInt32(ido_txtbox.Text);
                            CMD_INSERT_beszallito.Parameters.Add("@varos", MySqlDbType.String).Value = varos_txtbox.Text;
                            CMD_INSERT_beszallito.Parameters.Add("@cim", MySqlDbType.String).Value = cim_txtbox.Text;
                            CMD_INSERT_beszallito.Parameters.Add("@telefon", MySqlDbType.String).Value = telefon_txtbox.Text;
                            CMD_INSERT_beszallito.Parameters.Add("@email", MySqlDbType.String).Value = email_txtbox.Text;

                            if(CMD_INSERT_beszallito.ExecuteNonQuery()>0)
                            {
                                MessageBox.Show("Sikeres rögzítés!");
                            }
                            else
                            {
                                MessageBox.Show("Nem sikerült a rögzítés!");
                            }
                        }
                        else if(DT_select_besz != null && DT_select_besz.Rows.Count > 0)
                        {
                            MessageBox.Show("Ilyen beszállító már van!");
                        }
                        mysqlcon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Töltse ki a hiányos mezőket!");
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
    }
}
