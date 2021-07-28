using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raktár
{
    public partial class Hely : Form
    {
        Form frm;
        DataGridView dgv;

        public Hely(Form f, DataGridView datagrid)
        {
            InitializeComponent();
            this.frm = f;
            this.dgv = datagrid;
            epulet_combo.Items.Add("1");
            epulet_combo.Items.Add("2");
            epulet_combo.Items.Add("3");
            raktar_combo.Items.Add("1");
            raktar_combo.Items.Add("2");
            for (int i = 1; i < 41; i++)
            {
                oszlop_combo.Items.Add(i.ToString());
            }
            for (int i = 1; i < 7; i++)
            {
                polc_combo.Items.Add(i.ToString());
            }
            for (int i = 1; i < 7; i++)
            {
                box_combo.Items.Add(i.ToString());
            }

            epulet_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            raktar_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            oszlop_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            polc_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            box_combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Hely_kereses(string query, DataGridView dgv)
        {
            var DT_hely = new DataTable();

            string sql = query;

            using (var con = new MySqlConnection(Ipcim.constr))
            using (var cmd = new MySqlCommand(sql, con))
            using (var sda = new MySqlDataAdapter(cmd))
            {
                if(!String.IsNullOrWhiteSpace(epulet_combo.Text))
                {
                    cmd.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                }
                if (!String.IsNullOrWhiteSpace(raktar_combo.Text))
                {
                    cmd.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar_combo.Text);
                }
                if (!String.IsNullOrWhiteSpace(oszlop_combo.Text))
                {
                    cmd.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop_combo.Text);
                }
                if (!String.IsNullOrWhiteSpace(polc_combo.Text))
                {
                    cmd.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc_combo.Text);
                }
                if (!String.IsNullOrWhiteSpace(box_combo.Text))
                {
                    cmd.Parameters.Add("@box", MySqlDbType.Int32).Value = Convert.ToInt32(box_combo.Text);
                }

                sda.Fill(DT_hely);

                if(DT_hely!=null && DT_hely.Rows.Count>0)
                {
                    dgv.DataSource = DT_hely;
                    dgv.Refresh();
                }
                if (DT_hely == null || DT_hely.Rows.Count == 0)
                {
                    MessageBox.Show("Nincs találat a keresésre!");
                    dgv.DataSource = null;
                    dgv.Refresh();
                }
            }
        }

        private void helykereses_Btn_Click(object sender, EventArgs e)
        {
            if(epulet_check.Checked && !raktar_check.Checked && !oszlop_check.Checked && !polc_check.Checked && !box_check.Checked)
            {
                string QUERY_SELECT_hely = Adatbazis.cikk_query + "WHERE Épület=@epulet";
                Hely_kereses(QUERY_SELECT_hely, this.dgv);
            }
            else if(epulet_check.Checked && raktar_check.Checked && !oszlop_check.Checked && !polc_check.Checked && !box_check.Checked)
            {
                string QUERY_SELECT_hely = Adatbazis.cikk_query + "WHERE Épület=@epulet AND Raktár=@raktar";
                Hely_kereses(QUERY_SELECT_hely, this.dgv);
            }
            else if(epulet_check.Checked && raktar_check.Checked && oszlop_check.Checked && !polc_check.Checked && !box_check.Checked)
            {
                string QUERY_SELECT_hely = Adatbazis.cikk_query + "WHERE Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop";
                Hely_kereses(QUERY_SELECT_hely, this.dgv);
            }
            else if(epulet_check.Checked && raktar_check.Checked && oszlop_check.Checked && polc_check.Checked && !box_check.Checked)
            {
                string QUERY_SELECT_hely = Adatbazis.cikk_query + "WHERE Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc";
                Hely_kereses(QUERY_SELECT_hely, this.dgv);
            }
            else if (epulet_check.Checked && raktar_check.Checked && oszlop_check.Checked && polc_check.Checked && box_check.Checked)
            {
                string QUERY_SELECT_hely = Adatbazis.cikk_query + "WHERE Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc AND Box=@box";
                Hely_kereses(QUERY_SELECT_hely, this.dgv);
            }
        }
    }
}
