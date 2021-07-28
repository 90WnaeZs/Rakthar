using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Raktár.Közös_osztályok;

namespace Raktár
{
    public partial class Ujfelhasznalo : Form
    {
        public Ujfelhasznalo()
        {
            InitializeComponent();
            munkakor_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            munkakor_combo.Items.Add("gazdálkodó");
            munkakor_combo.Items.Add("műszerész");
            munkakor_combo.Items.Add("raktáros");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                bool ures_mezok = false;
                bool emailcheck;
                bool jelszocheck;
                bool jelszo_hossz;
                bool jelszo_jelszomegint;
                bool valid_jelszo;

                if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
                {
                    ures_mezok = false;
                }
                else
                {
                    ures_mezok = true;
                    error += "Hiányos adatok!" + Environment.NewLine;
                }

                if(!ures_mezok)
                {
                    Regex regex_email = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
                    Regex regex_password = new Regex("^(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$");
                    
                    emailcheck = regex_email.IsMatch(email_Txt.Text);
                    jelszocheck = regex_password.IsMatch(jelszo_Txt.Text);
                    valid_jelszo = false;
                    jelszo_hossz = jelszo_Txt.Text.Length >= 8;
                    jelszo_jelszomegint = jelszo_Txt.Text == jelszomegint_Txt.Text;

                    var data = Encoding.ASCII.GetBytes(jelszo_Txt.Text);
                    var md5 = new MD5CryptoServiceProvider();
                    var md5data = md5.ComputeHash(data);
                    string pwhash = "";

                    foreach (var item in data)
                    {
                        pwhash += item;
                    }

                    if (!jelszo_hossz)
                    {
                        error += "Túl rövid jelszó!" + Environment.NewLine;
                        password_checked.Visible = true;
                    }
                    if (!jelszocheck)
                    {
                        error += "A jelszónak tartalmaznia kell kis és nagybetűt, illetve számot!" + Environment.NewLine;
                        password_checked.Visible = true;
                    }
                    if (!jelszo_jelszomegint)
                    {
                        error += "A jelszavak nem egyeznek" + Environment.NewLine;
                        pwagain_checked.Visible = true;
                    }
                    if (!emailcheck)
                    {
                        error += "Hibás email cím formátum!" + Environment.NewLine;
                        email_checked.Visible = true;
                    }
                    if (jelszocheck && jelszo_hossz && jelszo_jelszomegint)
                    {
                        valid_jelszo = true;
                    }

                    if (valid_jelszo && emailcheck)
                    {
                        DataTable DT_SELECT_userinfo = new DataTable();

                        string QUERY_SELECT_userinfo = "SELECT * FROM felhasznalok WHERE Username=@username OR Email=@email";
                        string QUERY_INSERT_newuser = "INSERT INTO felhasznalok (Username,Password,Munkakör,Email) VALUES (@ins_username,@ins_pw,@ins_munkakor,@ins_email)";

                        using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                        using (MySqlCommand CMD_SELECT_userinfo = new MySqlCommand(QUERY_SELECT_userinfo, mysqlcon))
                        using (MySqlDataAdapter SDA_SELECT_userinfo = new MySqlDataAdapter(CMD_SELECT_userinfo))
                        {
                            mysqlcon.Open();

                            CMD_SELECT_userinfo.Parameters.Add("@username", MySqlDbType.String).Value = felhasznalo_Txt.Text;
                            CMD_SELECT_userinfo.Parameters.Add("@email", MySqlDbType.String).Value = email_Txt.Text;

                            SDA_SELECT_userinfo.Fill(DT_SELECT_userinfo);

                            bool van_ilyen_user = DT_SELECT_userinfo.AsEnumerable().Any(row => felhasznalo_Txt.Text == row.Field<String>("Username"));
                            bool van_ilyen_email = DT_SELECT_userinfo.AsEnumerable().Any(row => email_Txt.Text == row.Field<String>("Email"));

                            if (van_ilyen_user)
                            {
                                user_checked.Visible = true;
                                error += "Ez a felhasználónév már foglalt!" + Environment.NewLine;
                            }
                            if (van_ilyen_email)
                            {
                                email_checked.Visible = true;
                                error += "Ez az email cím már regisztrálva van!" + Environment.NewLine;
                            }

                            if (!van_ilyen_user && !van_ilyen_email)
                            {
                                using (MySqlCommand CMD_INSERT_newuser = new MySqlCommand(QUERY_INSERT_newuser, mysqlcon))
                                {
                                    CMD_INSERT_newuser.Parameters.Add("@ins_username", MySqlDbType.String).Value = felhasznalo_Txt.Text;
                                    CMD_INSERT_newuser.Parameters.Add("@ins_pw", MySqlDbType.String).Value = pwhash;
                                    CMD_INSERT_newuser.Parameters.Add("@ins_munkakor", MySqlDbType.String).Value = munkakor_combo.Text;
                                    CMD_INSERT_newuser.Parameters.Add("@ins_email", MySqlDbType.String).Value = email_Txt.Text;

                                    if (CMD_INSERT_newuser.ExecuteNonQuery()>0)
                                    {
                                        MessageBox.Show("Sikeres regisztráció!");
                                    }
                                    else
                                    {
                                        error += "Nem sikerült a regisztráció!" + Environment.NewLine;
                                    }
                                }
                            }
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

        #region Vizuális változtatások
        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }
        private void felhasznalo_Txt_TextChanged(object sender, EventArgs e)
        {
            user_checked.Visible = false;
            munkakor_checked.Visible = false;
            email_checked.Visible = false;
            password_checked.Visible = false;
            pwagain_checked.Visible = false;

            if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Black;
                reg_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) || String.IsNullOrWhiteSpace(jelszo_Txt.Text) || String.IsNullOrWhiteSpace(munkakor_combo.Text) || String.IsNullOrWhiteSpace(email_Txt.Text) || String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Gray;
                reg_Btn.Refresh();
            }
        }

        private void jelszo_Txt_TextChanged(object sender, EventArgs e)
        {
            user_checked.Visible = false;
            munkakor_checked.Visible = false;
            email_checked.Visible = false;
            password_checked.Visible = false;
            pwagain_checked.Visible = false;

            if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Black;
                reg_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) || String.IsNullOrWhiteSpace(jelszo_Txt.Text) || String.IsNullOrWhiteSpace(munkakor_combo.Text) || String.IsNullOrWhiteSpace(email_Txt.Text) || String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Gray;
                reg_Btn.Refresh();
            }
        }

        private void email_Txt_TextChanged(object sender, EventArgs e)
        {
            user_checked.Visible = false;
            munkakor_checked.Visible = false;
            email_checked.Visible = false;
            password_checked.Visible = false;
            pwagain_checked.Visible = false;

            if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Black;
                reg_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) || String.IsNullOrWhiteSpace(jelszo_Txt.Text) || String.IsNullOrWhiteSpace(munkakor_combo.Text) || String.IsNullOrWhiteSpace(email_Txt.Text) || String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Gray;
                reg_Btn.Refresh();
            }
        }

        private void munkakor_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_checked.Visible = false;
            munkakor_checked.Visible = false;
            email_checked.Visible = false;
            password_checked.Visible = false;
            pwagain_checked.Visible = false;

            if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Black;
                reg_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) || String.IsNullOrWhiteSpace(jelszo_Txt.Text) || String.IsNullOrWhiteSpace(munkakor_combo.Text) || String.IsNullOrWhiteSpace(email_Txt.Text) || String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Gray;
                reg_Btn.Refresh();
            }
        }

        private void jelszomegint_Txt_TextChanged(object sender, EventArgs e)
        {
            user_checked.Visible = false;
            munkakor_checked.Visible = false;
            email_checked.Visible = false;
            password_checked.Visible = false;
            pwagain_checked.Visible = false;

            if (!String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) && !String.IsNullOrWhiteSpace(jelszo_Txt.Text) && !String.IsNullOrWhiteSpace(munkakor_combo.Text) && !String.IsNullOrWhiteSpace(email_Txt.Text) && !String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Black;
                reg_Btn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(felhasznalo_Txt.Text) || String.IsNullOrWhiteSpace(jelszo_Txt.Text) || String.IsNullOrWhiteSpace(munkakor_combo.Text) || String.IsNullOrWhiteSpace(email_Txt.Text) || String.IsNullOrWhiteSpace(jelszomegint_Txt.Text))
            {
                reg_Btn.ForeColor = Color.Gray;
                reg_Btn.Refresh();
            }
        }
        #endregion

    }
}
