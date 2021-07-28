using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raktár.Al_Formok
{
    public partial class MettolMeddig : Form
    {
        Form frm;
        DataGridView szures_dgv;
        RadioButton rendel;
        RadioButton varhat;
        RadioButton karban;
        RadioButton utem;
        RadioButton selejt;
        public MettolMeddig(Form f,DataGridView dgv,RadioButton rendelve,RadioButton varhato,RadioButton karbantartva,RadioButton utemezett,RadioButton selejtezett)
        {
            InitializeComponent();
            this.frm = f;
            this.szures_dgv = dgv;

            if(rendelve!=null)
            {
                this.rendel = rendelve;
            }
            if(varhato != null)
            {
                this.varhat = varhato;
            }
            if (karbantartva != null)
            {
                this.karban = karbantartva;
            }
            if (utemezett != null)
            {
                this.utem = utemezett;
            }
            if (selejtezett != null)
            {
                this.selejt = selejtezett;
            }
        }

        private void Szures(string query,string oszlop)
        {
            var result = new DataTable();

            string sql = query + "WHERE " + oszlop + " >= @StartDate AND " + oszlop + " <= @EndDate ";

            using (var con = new MySqlConnection(Ipcim.constr))
            using (var cmd = new MySqlCommand(sql, con))
            using (var sda = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@StartDate", MySqlDbType.Date).Value = mettolDateTime.Value.Date;
                cmd.Parameters.Add("@EndDate", MySqlDbType.Date).Value = meddigDateTime.Value.Date;

                sda.Fill(result);
            }
            szures_dgv.DataSource = result;
        }

        private void kereses_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rendel!=null && rendel.Checked)
                {
                    Szures(Adatbazis.rendeles_query, "Rendelve");
                    rendel.Checked = false;
                }
                else if (varhat != null && varhat.Checked)
                {
                    Szures(Adatbazis.rendeles_query, "Érkezés");
                    varhat.Checked = false;
                }
                else if (karban != null && karban.Checked)
                {
                    Szures(Adatbazis.karb_query, "Karbantartva");
                    karban.Checked = false;
                }
                else if (utem != null && utem.Checked)
                {
                    Szures(Adatbazis.utemezett_query, "Dátum");
                    utem.Checked = false;
                }
                else if (selejt != null && selejt.Checked)
                {
                    Szures(Adatbazis.selejtezes_query, "Dátum");
                    selejt.Checked = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Nem várt hiba!"+" "+error.Message);
            }
            

        }
    }
}
