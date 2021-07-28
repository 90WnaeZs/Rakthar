using System;
using System.Linq;
using System.Windows.Forms;

namespace Raktár.Main_Formok
{
    class FormEllenorzo
    {
        public static bool isopen =false;

        public static void form_ellenorzes(string formnev) // Egy formot csak egyszer nyisson meg
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == formnev)
                {
                    isopen = true;
                    f.BringToFront();
                    break;
                }
                else
                {
                    isopen = false;
                }
            }
        }

        public static void form_bezaro(string formnev)
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == formnev)
                {
                    f.Close();
                    break;
                }
            }
        }

        public static void GroupBox_kezelo(string groupbox, GroupBox mainGB) // a Main Formokban mindig csak azok a GroupBoxok legyenek láthatók, amelyeket épp használunk
        {
            var GBs = mainGB.Controls.OfType<GroupBox>();
            foreach (GroupBox GB in GBs)
            {
                if (GB.Name == "load_GB" || GB.Name == groupbox)
                {
                    GB.Visible = true;
                }
                else
                {
                    GB.Visible = false;
                }
            }
        }

        public static void vissza_Loginhoz<T>(T f) where T : Form
        {
            Login log = new Login();
            log.Show();
            f.Dispose();

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Login")
                    Application.OpenForms[i].Close();
            }
        }

        public static bool Bevitel_ellenorzo(Form f)  // Leellenőrzi, hogy a formon belül vannak-e üres mezők
        {
            int counter = 0;

            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        if (String.IsNullOrWhiteSpace((control as TextBox).Text))
                        {
                            counter++;
                        }
                    }
                    if (control is ComboBox)
                    {
                        if (String.IsNullOrWhiteSpace((control as ComboBox).Text))
                        {
                            counter++;
                        }
                    }
                    if (control is NumericUpDown)
                    {
                        if (String.IsNullOrWhiteSpace((control as NumericUpDown).Text))
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };

            func(f.Controls);

            if(counter==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
