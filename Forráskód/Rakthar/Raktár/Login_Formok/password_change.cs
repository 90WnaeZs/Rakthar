using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace Raktár
{
    public partial class Jelszovaltas : Form
    {
        public Jelszovaltas()
        {
            InitializeComponent();
        }

        #region Jelszó változtatás
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool ures_mezok = true;
                bool van_ilyen_user = false;
                bool megfelelo_uj_jelszo = false;
                string error = "";

                if (!String.IsNullOrWhiteSpace(email_Txtbox.Text) && !String.IsNullOrWhiteSpace(regi_Txtbox.Text) && !String.IsNullOrWhiteSpace(uj_Txtbox.Text) && !String.IsNullOrWhiteSpace(ujmegint_Txtbox.Text))
                {
                    ures_mezok = false;
                }
                else
                {
                    ures_mezok = true;
                }

                if (ures_mezok)
                {
                    error += "Töltse ki az üres mezőket!" + Environment.NewLine;
                }
                else if (!ures_mezok)
                {
                    var pw_data = Encoding.ASCII.GetBytes(regi_Txtbox.Text);
                    var pw_md5 = new MD5CryptoServiceProvider();
                    var pw_md5data = pw_md5.ComputeHash(pw_data);
                    string regipwhash = "";

                    foreach (var item in pw_data)
                    {
                        regipwhash += item;
                    }

                    var pw_data2 = Encoding.ASCII.GetBytes(uj_Txtbox.Text);
                    var pw_md5_2 = new MD5CryptoServiceProvider();
                    var pw_md5data2 = pw_md5_2.ComputeHash(pw_data2);
                    string ujpwhash = "";

                    foreach (var item in pw_data2)
                    {
                        ujpwhash += item;
                    }

                    Regex regex = new Regex("^(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$");
                    bool jelszocheck = regex.IsMatch(uj_Txtbox.Text);

                    if (uj_Txtbox.Text == ujmegint_Txtbox.Text && uj_Txtbox.Text.Length >= 8 && ujmegint_Txtbox.Text.Length >= 8 && jelszocheck)
                    {
                        megfelelo_uj_jelszo = true;
                    }
                    else
                    {
                        megfelelo_uj_jelszo = false;
                        error += "A jelszónak 8 KARAKTER HOSSZÚnak kell lenni, és tartalmaznia kell KIS és NAGY betűt!" + Environment.NewLine;
                    }

                    if (megfelelo_uj_jelszo)
                    {
                        DataTable DT_email = new DataTable();
                        DataTable DT_pw = new DataTable();

                        string QUERY_SELECT_email = "SELECT Email FROM felhasznalok WHERE Email=@email AND Password=@regi_pw";
                        string QUERY_UPDATE_pw = "UPDATE felhasznalok SET Password=@upd_uj_pw WHERE Email=@upd_email";

                        using (MySqlConnection mysqlcon_pw = new MySqlConnection(Ipcim.constr))
                        using (MySqlCommand CMD_SELECT_email = new MySqlCommand(QUERY_SELECT_email, mysqlcon_pw))
                        using (MySqlDataAdapter SDA_SELECT_email = new MySqlDataAdapter(CMD_SELECT_email))
                        using (MySqlCommand CMD_UPDATE_pw = new MySqlCommand(QUERY_UPDATE_pw, mysqlcon_pw))
                        {
                            mysqlcon_pw.Open();
                            CMD_SELECT_email.Parameters.Add("@email", MySqlDbType.String).Value = email_Txtbox.Text;
                            CMD_SELECT_email.Parameters.Add("@regi_pw", MySqlDbType.String).Value = regipwhash;
                            SDA_SELECT_email.Fill(DT_email);

                            if (DT_email != null && DT_email.Rows.Count > 0)
                            {
                                van_ilyen_user = true;
                            }
                            else if (DT_email != null && DT_email.Rows.Count == 0)
                            {
                                van_ilyen_user = false;
                                error += "Hibás emailcím, vagy jelszó!" + Environment.NewLine;
                            }

                            if (van_ilyen_user)
                            {
                                CMD_UPDATE_pw.Parameters.Add("@upd_uj_pw", MySqlDbType.String).Value = ujpwhash;
                                CMD_UPDATE_pw.Parameters.Add("@upd_email", MySqlDbType.String).Value = email_Txtbox.Text;

                                if(CMD_UPDATE_pw.ExecuteNonQuery()>0)
                                {
                                    MessageBox.Show("Sikeres jelszóváltoztatás!");
                                }
                                else
                                {
                                    error += "Nem sikerült a jelszóváltoztatás!" + Environment.NewLine;
                                }
                                
                            }
                            else if (!van_ilyen_user)
                            {
                                error += "Nincs ilyen felhasználó!" + Environment.NewLine;
                            }
                            mysqlcon_pw.Close();
                        }
                    }
                }
                if (!String.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show(error, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    error = "";
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion

        #region Vizuális változtatások
        private void email_Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (email_Txtbox.TextLength > 0 && regi_Txtbox.TextLength > 0 && uj_Txtbox.TextLength > 0 && ujmegint_Txtbox.TextLength > 0)
            {
                change_Btn.ForeColor = Color.Black;
                change_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(email_Txtbox.Text) || String.IsNullOrWhiteSpace(regi_Txtbox.Text) || String.IsNullOrWhiteSpace(uj_Txtbox.Text) || String.IsNullOrWhiteSpace(ujmegint_Txtbox.Text))
            {
                change_Btn.ForeColor = Color.Gray;
                change_Btn.Refresh();
            }
        }

        private void regi_Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (email_Txtbox.TextLength > 0 && regi_Txtbox.TextLength > 0 && uj_Txtbox.TextLength > 0 && ujmegint_Txtbox.TextLength > 0)
            {
                change_Btn.ForeColor = Color.Black;
                change_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(email_Txtbox.Text) || String.IsNullOrWhiteSpace(regi_Txtbox.Text) || String.IsNullOrWhiteSpace(uj_Txtbox.Text) || String.IsNullOrWhiteSpace(ujmegint_Txtbox.Text))
            {
                change_Btn.ForeColor = Color.Gray;
                change_Btn.Refresh();
            }
        }

        private void uj_Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (email_Txtbox.TextLength > 0 && regi_Txtbox.TextLength > 0 && uj_Txtbox.TextLength > 0 && ujmegint_Txtbox.TextLength > 0)
            {
                change_Btn.ForeColor = Color.Black;
                change_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(email_Txtbox.Text) || String.IsNullOrWhiteSpace(regi_Txtbox.Text) || String.IsNullOrWhiteSpace(uj_Txtbox.Text) || String.IsNullOrWhiteSpace(ujmegint_Txtbox.Text))
            {
                change_Btn.ForeColor = Color.Gray;
                change_Btn.Refresh();
            }
        }

        private void ujmegint_Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (email_Txtbox.TextLength > 0 && regi_Txtbox.TextLength > 0 && uj_Txtbox.TextLength > 0 && ujmegint_Txtbox.TextLength > 0)
            {
                change_Btn.ForeColor = Color.Black;
                change_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(email_Txtbox.Text) || String.IsNullOrWhiteSpace(regi_Txtbox.Text) || String.IsNullOrWhiteSpace(uj_Txtbox.Text) || String.IsNullOrWhiteSpace(ujmegint_Txtbox.Text))
            {
                change_Btn.ForeColor = Color.Gray;
                change_Btn.Refresh();
            }
        }
        #endregion


        #region Form bezárás
        private void Jelszovaltas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Login")
                    Application.OpenForms[i].Close();
            }
        }
        #endregion

    }
}
