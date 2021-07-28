using System;
using System.Linq;
using System.Windows.Forms;

namespace Raktár.Közös_osztályok
{
    class Reset
    {
        public static void ClearAll(Form f)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is ComboBox)
                    {
                        (control as ComboBox).ResetText();
                        (control as ComboBox).SelectedIndex = -1;
                    }
                    else if(control is TextBox)
                    {
                        (control as TextBox).ResetText();
                    }
                    else if (control is NumericUpDown)
                    {
                        (control as NumericUpDown).ResetText();
                    }
                    else if (control is RadioButton)
                    {
                        (control as RadioButton).Checked=false;
                    }
                    else if (control is PictureBox)
                    {
                        if((control as PictureBox).Name== "downarrow")
                        {
                            (control as PictureBox).Visible = false;
                        }
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };

            func(f.Controls);
        }

        public static void ClearRadioButtons(Form f,RadioButton main_rb)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is RadioButton && control.Name != main_rb.Name)
                    {
                        (control as RadioButton).Checked=false;
                    }
                }
            };

            func(f.Controls);
        }

    }
}
