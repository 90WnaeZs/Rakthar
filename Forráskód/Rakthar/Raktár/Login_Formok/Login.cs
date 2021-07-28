using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using Raktár.Main_Formok;

namespace Raktár
{
    public partial class Login : Form
    {
        #region Form indítás

        bool login_ures = false;
        int login_counter = 0;
        MySqlConnection mysqlcon;
        MySqlCommand cmd;
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = lgn_username_combo;
            timer1.Start();
            Ipcim.megadott_ip = Properties.Settings.Default.Ipcim;
            Ipcim.constr = Properties.Settings.Default.Constring;
            Ipcim.megadott_port = Properties.Settings.Default.Port;
            Ipcim.megadott_username = Properties.Settings.Default.Username;
            Ipcim.megadott_password = Properties.Settings.Default.Password;
            using (mysqlcon = new MySqlConnection(Ipcim.constr))
            {
                try
                {
                    mysqlcon.Open();
                    MySqlCommand comm = new MySqlCommand("Select Username From felhasznalok", mysqlcon);
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        lgn_username_combo.Items.Add(reader.GetString("Username"));
                    }
                    mysqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Adatbazis.mysqlcon = new MySqlConnection(Ipcim.constr);
        }
        #endregion

        #region helyi metódusok
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                MessageBox.Show(Convert.ToBase64String(data));
                return Convert.ToBase64String(data);
            }
        }
        public string Query(string query)
        {
            string x;
            mysqlcon.Open();
            cmd = new MySqlCommand(query, mysqlcon);
            x = cmd.ExecuteScalar().ToString();
            mysqlcon.Close();
            return x;
        }
        #endregion

        #region színek változtatása
        private void lgn_usernameTxt_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lgn_username_combo.Text) && !String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
            {
                loginFrm_loginBtn.ForeColor = Color.Black;
                loginFrm_loginBtn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(lgn_username_combo.Text) || String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
            {
                loginFrm_loginBtn.ForeColor = Color.Gray;
                loginFrm_loginBtn.Refresh();
            }
        }

        private void lgn_passwordTxt_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lgn_username_combo.Text) && !String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
            {
                loginFrm_loginBtn.ForeColor = Color.Black;
                loginFrm_loginBtn.Refresh();
            }

            if (String.IsNullOrWhiteSpace(lgn_username_combo.Text) || String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
            {
                loginFrm_loginBtn.ForeColor = Color.Gray;
                loginFrm_loginBtn.Refresh();
            }
        }
        #endregion

        #region Bejelentkezés
        public void loginFrm_loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(lgn_username_combo.Text) && !String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
                {
                    login_ures = false;
                }
                else if (String.IsNullOrWhiteSpace(lgn_username_combo.Text) || String.IsNullOrWhiteSpace(lgn_passwordTxt.Text))
                {
                    login_ures = true;
                    MessageBox.Show("Írja be a felhasználónevét és jelszavát!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (!login_ures)
                {
                    DataTable log_dt = new DataTable();

                    string munka_sql = "Select * From felhasznalok Where Username= @user And Password= @pw";
                    string bejelentkezes = "INSERT INTO bejelentkezes (User_ID,Date) values(@be_user, @be_date)";

                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand cmd = new MySqlCommand(munka_sql, mysqlcon))
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        mysqlcon.Open();

                        string username = lgn_username_combo.Text;
                        string password = lgn_passwordTxt.Text;
                        Raktaros rak = new Raktaros();
                        Muszeresz musz = new Muszeresz();
                        Gazdalkodo gaz = new Gazdalkodo();

                        var data = Encoding.ASCII.GetBytes(lgn_passwordTxt.Text);
                        var md5 = new MD5CryptoServiceProvider();
                        var md5data = md5.ComputeHash(data);
                        string pwhash = "";

                        foreach (var item in data)
                        {
                            pwhash += item;
                        }

                        cmd.Parameters.Add("@user", MySqlDbType.String).Value = lgn_username_combo.Text;
                        cmd.Parameters.Add("@pw", MySqlDbType.String).Value = pwhash;

                        sda.Fill(log_dt);

                        bool raktáros = log_dt.AsEnumerable().Any(row => "raktáros" == row.Field<String>("munkakör"));
                        bool műszerész = log_dt.AsEnumerable().Any(row => "műszerész" == row.Field<String>("munkakör"));
                        bool gazdálkodó = log_dt.AsEnumerable().Any(row => "gazdálkodó" == row.Field<String>("munkakör"));

                        DataRow id_user_row;
                        string id_user = "";
                        if (log_dt!=null && log_dt.Rows.Count>0)
                        {
                            id_user_row = log_dt.Rows[0];
                            id_user = id_user_row["ID_User"].ToString();
                        }

                        if (raktáros)
                        {
                            using (MySqlCommand be_cmd = new MySqlCommand(bejelentkezes, mysqlcon))
                            {
                                be_cmd.Parameters.Add("@be_user", MySqlDbType.String).Value = id_user;
                                be_cmd.Parameters.Add("@be_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            rak.LabelText = "Bejelentkezve: " + lgn_username_combo.Text;
                            this.Hide();
                            rak.Show();
                        }
                        else if (műszerész)
                        {
                            using (MySqlCommand be_cmd = new MySqlCommand(bejelentkezes, mysqlcon))
                            {
                                be_cmd.Parameters.Add("@be_user", MySqlDbType.String).Value = id_user;
                                be_cmd.Parameters.Add("@be_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            musz.LabelText = "Bejelentkezve: " + lgn_username_combo.Text;
                            this.Hide();
                            musz.Show();

                        }
                        else if (gazdálkodó)
                        {
                            using (MySqlCommand be_cmd = new MySqlCommand(bejelentkezes, mysqlcon))
                            {
                                be_cmd.Parameters.Add("@be_user", MySqlDbType.String).Value = id_user;
                                be_cmd.Parameters.Add("@be_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            gaz.LabelText = "Bejelentkezve: " + lgn_username_combo.Text;
                            this.Hide();
                            gaz.Show();
                        }
                        else
                        {
                            MessageBox.Show("Hibás felhasználónév, vagy jelszó!", "Próbálkozások száma: " + (login_counter + 1), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            login_counter++;
                            if (login_counter == 3)
                            {
                                this.Close();
                            }
                        }
                    }
                    mysqlcon.Close();
                }
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }
        #endregion

        #region idő
        private void timer1_Tick(object sender, EventArgs e)
        {
            Login_timelbl.Text = DateTime.Now.ToString();
        }
        #endregion

        #region alformok
        private void jelszoBtn_Click(object sender, EventArgs e)
        {
            bool isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Jelszovaltas")
                {
                    isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (!isopen)
            {
                Jelszovaltas pwchange = new Jelszovaltas();
                pwchange.Show();
            }
        }

        private void ujfelhasznalo_Btn_Click(object sender, EventArgs e)
        {
            bool isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Ujfelhasznalo")
                {
                    isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (!isopen)
            {
                Ujfelhasznalo uj = new Ujfelhasznalo();
                uj.Show();
            }
        }
        private void ipcim_Btn_Click(object sender, EventArgs e)
        {
            bool isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Ipcim")
                {
                    isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (!isopen)
            {
                Ipcim ipc = new Ipcim();
                ipc.Show();
            }
        }
        #endregion

        #region keydown
        private void lgn_username_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginFrm_loginBtn_Click(this, new EventArgs());
            }
        }

        private void lgn_passwordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginFrm_loginBtn_Click(this, new EventArgs());
            }
        }
        #endregion

        #region bezárás
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }
        #endregion
    }
}
