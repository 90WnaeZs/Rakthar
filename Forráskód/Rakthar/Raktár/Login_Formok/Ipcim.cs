using System;
using System.Windows.Forms;


namespace Raktár
{
    public partial class Ipcim : Form
    {
        public static string megadott_ip;
        public static string megadott_port;
        public static string megadott_username;
        public static string megadott_password;
        public static string constr;
        
        int szamlalo = 0;
            
        public Boolean CheckIPValid(String strIP)
        {
            char chrFullStop = '.';
            string[] arrOctets = strIP.Split(chrFullStop);
            if (arrOctets.Length != 4)
            {
                return false;
            }
            Int16 MAXVALUE = 255;
            Int32 temp; // Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }

                temp = int.Parse(strOctet);
                if (temp > MAXVALUE)
                {
                    return false;
                }
            }
            return true;
        }
        public Ipcim()
        {
            InitializeComponent();
            ipcim_Lbl.Text = "Beállított IP cím: " + Properties.Settings.Default.Ipcim;
            megadott_ip = Properties.Settings.Default.Ipcim;
            megadott_port = Properties.Settings.Default.Port;
            megadott_username = Properties.Settings.Default.Username;
            megadott_password = Properties.Settings.Default.Password;
            constr = Properties.Settings.Default.Constring;
            ipcim_txtbox.Text = Properties.Settings.Default.Ipcim;
            port_txtbox.Text = Properties.Settings.Default.Port;
            user_txtbox.Text = Properties.Settings.Default.Username;
            pw_txtbox.Text = Properties.Settings.Default.Password;
        }

        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox && !String.IsNullOrWhiteSpace(c.Text))
                    {
                        szamlalo++;
                    }
                }
                if (CheckIPValid(ipcim_txtbox.Text) && szamlalo>=2)
                {
                    megadott_ip = ipcim_txtbox.Text;
                    Properties.Settings.Default.Ipcim = megadott_ip;
                    megadott_port = port_txtbox.Text;
                    Properties.Settings.Default.Port = megadott_port;
                    megadott_username = user_txtbox.Text;
                    Properties.Settings.Default.Username = megadott_username;
                    megadott_password = pw_txtbox.Text;
                    Properties.Settings.Default.Password = megadott_password;

                    constr = "datasource=" + Properties.Settings.Default.Ipcim + ";port=" + Properties.Settings.Default.Port + ";username=" + Properties.Settings.Default.Username + ";password=" + Properties.Settings.Default.Password + ";database=raktar";

                    Properties.Settings.Default.Constring = constr;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    ipcim_Lbl.Text = "Beállított IP cím: " + Properties.Settings.Default.Ipcim;

                    MessageBox.Show("Sikeres mentés!");
                }
                else if (szamlalo<2)
                {
                    MessageBox.Show("Töltse ki a mezőket!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Hibás IP cím!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
