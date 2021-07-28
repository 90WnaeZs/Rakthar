using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;

namespace Raktár
{
    public partial class Beszmod : Form
    {
        string beszID;
        public Beszmod()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
            beszallito_combo.DropDownStyle = ComboBoxStyle.DropDown;
            beszID = "";
        }
        
        private void betoltes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DT_SELECT_beszallito = new DataTable();

                string SELECT_beszallito_adatok ="SELECT * FROM beszallito WHERE Beszállító_név=@besz_nev";

                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                using (MySqlCommand CMD_SELECT_beszallito = new MySqlCommand(SELECT_beszallito_adatok, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_beszallito = new MySqlDataAdapter(CMD_SELECT_beszallito))
                {
                    mysqlcon.Open();

                    CMD_SELECT_beszallito.Parameters.Add("@besz_nev", MySqlDbType.String).Value = beszallito_combo.Text;

                    SDA_SELECT_beszallito.Fill(DT_SELECT_beszallito);

                    if(DT_SELECT_beszallito!=null && DT_SELECT_beszallito.Rows.Count>0)
                    {
                        foreach (DataRow row in DT_SELECT_beszallito.Rows)
                        {
                            beszID = row["ID_Beszállító"].ToString();
                            besznev_txtbox.Text = row["Beszállító_név"].ToString();
                            ido_txtbox.Text = row["Szállítási_idő"].ToString();
                            varos_txtbox.Text = row["Város"].ToString();
                            cim_txtbox.Text = row["Cím"].ToString();
                            telefon_txtbox.Text = row["Telefonszám"].ToString();
                            email_txtbox.Text = row["Emailcím"].ToString();
                        }
                    }
                    else if(DT_SELECT_beszallito == null || DT_SELECT_beszallito.Rows.Count == 0)
                    {
                        MessageBox.Show("Nincs ilyen beszállító!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                string UPDATE_beszallito_adatok = "UPDATE beszallito SET Beszállító_név=@upd_besz_nev, Szállítási_idő=@upd_szall_ido, Város=@upd_varos, Cím=@upd_cim, Telefonszám=@upd_telefon, Emailcím=@upd_email WHERE ID_Beszállító=@upd_beszID";

                if (!String.IsNullOrWhiteSpace(beszID))
                {
                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_UPDATE_beszallito = new MySqlCommand(UPDATE_beszallito_adatok, mysqlcon))
                    {
                        mysqlcon.Open();

                        CMD_UPDATE_beszallito.Parameters.Add("@upd_besz_nev", MySqlDbType.String).Value = besznev_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_szall_ido", MySqlDbType.Int32).Value = ido_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_varos", MySqlDbType.String).Value = varos_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_cim", MySqlDbType.String).Value = cim_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_telefon", MySqlDbType.String).Value = telefon_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_email", MySqlDbType.String).Value = email_txtbox.Text;
                        CMD_UPDATE_beszallito.Parameters.Add("@upd_beszID", MySqlDbType.Int32).Value = beszID;

                        if(CMD_UPDATE_beszallito.ExecuteNonQuery()>0)
                        {
                            MessageBox.Show("Sikeres módosítás!");
                        }
                        else
                        {
                            MessageBox.Show("Nem sikerült a módosítás!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nincs ilyen beszállító!");
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
