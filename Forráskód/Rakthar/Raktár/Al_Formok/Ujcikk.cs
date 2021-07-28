using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Raktár.Közös_osztályok;

namespace Raktár
{
    public partial class Ujcikk : Form
    {
        string error = "";
        bool min_max_megfelelo = false;
        bool mennyiseg_megfelelo = false;
        bool osszes_kitoltve = false;
        
        public Ujcikk()
        {
            InitializeComponent();
            ComboBoxKezelo.ComboBoxFeltoltes(this);
        }
        private void mentes_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!(String.IsNullOrWhiteSpace(cikknev_txtbox.Text) || String.IsNullOrWhiteSpace(gyartoi_txtbox.Text) || String.IsNullOrWhiteSpace(tipus_combo.Text)
                        || String.IsNullOrWhiteSpace(beszallito_combo.Text) || String.IsNullOrWhiteSpace(ar_num.Text) || String.IsNullOrWhiteSpace(epulet_combo.Text)
                        || String.IsNullOrWhiteSpace(raktar_combo.Text) || String.IsNullOrWhiteSpace(oszlop_combo.Text) || String.IsNullOrWhiteSpace(polc_combo.Text)
                        || String.IsNullOrWhiteSpace(box_combo.Text) || String.IsNullOrWhiteSpace(egyseg_combo.Text) || String.IsNullOrWhiteSpace(mennyi_num.Text)
                        || String.IsNullOrWhiteSpace(min_num.Text) || String.IsNullOrWhiteSpace(max_num.Text)))
                {
                    osszes_kitoltve = true;
                    if ((int.Parse(min_num.Text) < int.Parse(max_num.Text)) && (int.Parse(min_num.Text) > 0 && int.Parse(min_num.Text) > 0))
                    {
                        min_max_megfelelo = true;
                    }
                    else if (int.Parse(min_num.Text)==0 || int.Parse(max_num.Text)==0)
                    {
                        min_max_megfelelo = false;
                        error += "A minimum és maximum értéknek nagyobbnak kell lenni 0-nál!" + Environment.NewLine;
                    }
                    else if(int.Parse(min_num.Text) > int.Parse(max_num.Text))
                    {
                        min_max_megfelelo = false;
                        error += "A minimum érték nem lehet nagyobb a maximumnál!" + Environment.NewLine;
                    }
                    if(int.Parse(mennyi_num.Text) > 0)
                    {
                        mennyiseg_megfelelo = true;
                    }
                    else
                    {
                        mennyiseg_megfelelo = false;
                        error += "A megadott mennyiség nem lehet nulla!" + Environment.NewLine;
                    }
                }
                else
                {
                    error += "Hiányos adatok!" + Environment.NewLine;
                }
                

                if(osszes_kitoltve && min_max_megfelelo && mennyiseg_megfelelo)
                {
                    string ID_cikk = "";
                    string ID_mennyiseg = "";
                    string ID_beszallito = "";
                    bool nincs_cikk = false;
                    bool van_mennyiseg = false;
                    bool van_beszallito = false;

                    DataTable DT_SELECT_cikk = new DataTable();
                    DataTable DT_SELECT_IDcikk = new DataTable();
                    DataTable DT_SELECT_ID_mennyiseg = new DataTable();
                    DataTable DT_SELECT_ID_beszallito = new DataTable();

                    string QUERY_SELECT_cikk = "SELECT * FROM cikk WHERE Cikknév=@cikknev OR Gyártói=@gyartoi";
                    string QUERY_SELECT_IDcikk = "SELECT * FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                    string QUERY_SELECT_ID_mennyiseg = "SELECT ID_Mennyiség FROM mennyiseg WHERE Megnevezés=@egyseg";
                    string QUERY_SELECT_ID_beszallito = "SELECT ID_Beszállító FROM beszallito WHERE Beszállító_név=@besz_nev";
                    string QUERY_INSERT_cikk = "INSERT INTO cikk (Cikknév,Gyártói,Típus,Beszállító_ID,Ár,Mennyiség_ID,Minimum,Maximum) values (@cikknev,@gyartoi,@tipus,@IDbesz,@ar,@IDmennyiseg,@min,@max)";
                    string QUERY_INSERT_hely = "INSERT INTO hely (Cikk_ID,Mennyiség,Épület,Raktár,Oszlop,Polc,Box) values (@cikkID,@mennyiseg,@epulet,@raktar,@oszlop,@polc,@box)";

                    using (MySqlConnection mysqlcon=new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikk = new MySqlCommand(QUERY_SELECT_cikk, mysqlcon))
                    using (MySqlCommand CMD_SELECT_IDcikk = new MySqlCommand(QUERY_SELECT_IDcikk, mysqlcon))
                    using (MySqlCommand CMD_SELECT_ID_mennyiseg = new MySqlCommand(QUERY_SELECT_ID_mennyiseg, mysqlcon))
                    using (MySqlCommand CMD_SELECT_ID_besz = new MySqlCommand(QUERY_SELECT_ID_beszallito, mysqlcon))
                    using (MySqlCommand CMD_INSERT_cikk = new MySqlCommand(QUERY_INSERT_cikk, mysqlcon))
                    using (MySqlCommand CMD_INSERT_hely = new MySqlCommand(QUERY_INSERT_hely, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikk=new MySqlDataAdapter(CMD_SELECT_cikk))
                    using (MySqlDataAdapter SDA_SELECT_IDcikk = new MySqlDataAdapter(CMD_SELECT_IDcikk))
                    using (MySqlDataAdapter SDA_SELECT_ID_mennyiseg = new MySqlDataAdapter(CMD_SELECT_ID_mennyiseg))
                    using (MySqlDataAdapter SDA_SELECT_ID_beszallito = new MySqlDataAdapter(CMD_SELECT_ID_besz))
                    {
                        mysqlcon.Open();

                        CMD_SELECT_cikk.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_txtbox.Text;
                        CMD_SELECT_cikk.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_txtbox.Text;
                        SDA_SELECT_cikk.Fill(DT_SELECT_cikk);

                        if(DT_SELECT_cikk!=null && DT_SELECT_cikk.Rows.Count==0)
                        {
                            nincs_cikk = true;

                            CMD_SELECT_ID_mennyiseg.Parameters.Add("@egyseg", MySqlDbType.String).Value = egyseg_combo.Text;
                            SDA_SELECT_ID_mennyiseg.Fill(DT_SELECT_ID_mennyiseg);

                            if(DT_SELECT_ID_mennyiseg!=null && DT_SELECT_ID_mennyiseg.Rows.Count>0)
                            {
                                van_mennyiseg = true;
                                foreach (DataRow row in DT_SELECT_ID_mennyiseg.Rows)
                                {
                                    ID_mennyiseg = row["ID_Mennyiség"].ToString();
                                }
                            }
                            else if(DT_SELECT_ID_mennyiseg != null && DT_SELECT_ID_mennyiseg.Rows.Count == 0)
                            {
                                van_mennyiseg = false;
                                error += "Nincs ilyen mennyiség!" + Environment.NewLine;
                            }

                            CMD_SELECT_ID_besz.Parameters.Add("@besz_nev", MySqlDbType.String).Value = beszallito_combo.Text;
                            SDA_SELECT_ID_beszallito.Fill(DT_SELECT_ID_beszallito);

                            if (DT_SELECT_ID_beszallito != null && DT_SELECT_ID_beszallito.Rows.Count > 0)
                            {
                                van_beszallito = true;
                                foreach (DataRow row in DT_SELECT_ID_beszallito.Rows)
                                {
                                    ID_beszallito = row["ID_Beszállító"].ToString();
                                }
                            }
                            else if (DT_SELECT_ID_beszallito != null && DT_SELECT_ID_beszallito.Rows.Count == 0)
                            {
                                van_beszallito = false;
                                error += "Nincs ilyen beszállító!" + Environment.NewLine;
                            }

                        }
                        else if(DT_SELECT_cikk != null && DT_SELECT_cikk.Rows.Count > 0)
                        {
                            error += "Ilyen cikk, vagy gyártói szám már van!" + Environment.NewLine;
                        }

                        if(nincs_cikk && van_mennyiseg && van_beszallito)
                        {
                            CMD_INSERT_cikk.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_txtbox.Text;
                            CMD_INSERT_cikk.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_txtbox.Text;
                            CMD_INSERT_cikk.Parameters.Add("@tipus", MySqlDbType.String).Value = tipus_combo.Text;
                            CMD_INSERT_cikk.Parameters.Add("@IDbesz", MySqlDbType.Int32).Value = Convert.ToInt32(ID_beszallito);
                            CMD_INSERT_cikk.Parameters.Add("@ar", MySqlDbType.Int32).Value = Convert.ToInt32(ar_num.Text);
                            CMD_INSERT_cikk.Parameters.Add("@IDmennyiseg", MySqlDbType.Int32).Value = Convert.ToInt32(ID_mennyiseg);
                            CMD_INSERT_cikk.Parameters.Add("@min", MySqlDbType.Int32).Value = Convert.ToInt32(min_num.Text);
                            CMD_INSERT_cikk.Parameters.Add("@max", MySqlDbType.Int32).Value = Convert.ToInt32(max_num.Text);

                            CMD_SELECT_IDcikk.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev_txtbox.Text;
                            CMD_SELECT_IDcikk.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi_txtbox.Text;
                            SDA_SELECT_IDcikk.Fill(DT_SELECT_IDcikk);

                            if(DT_SELECT_IDcikk != null && DT_SELECT_IDcikk.Rows.Count > 0)
                            {
                                ID_cikk = DT_SELECT_IDcikk.Rows[0]["ID_Cikk"].ToString();
                            }
                            else if(DT_SELECT_IDcikk != null && DT_SELECT_IDcikk.Rows.Count == 0)
                            {
                                error += "Nincs ilyen cikk!" + Environment.NewLine;
                            }

                            CMD_INSERT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(ID_cikk);
                            CMD_INSERT_hely.Parameters.Add("@mennyiseg", MySqlDbType.Int32).Value = Convert.ToInt32(mennyi_num.Text);
                            CMD_INSERT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);
                            CMD_INSERT_hely.Parameters.Add("@box", MySqlDbType.Int32).Value = Convert.ToInt32(epulet_combo.Text);

                            if (CMD_INSERT_cikk.ExecuteNonQuery()>0 && CMD_INSERT_hely.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Sikeres rögzítés!");
                            }
                            else
                            {
                                error += "Nem sikerült a rögzítés!" + Environment.NewLine;
                            }
                        }
                    }
                }
                else if(!osszes_kitoltve)
                {
                    error += "Töltse ki az üres mezőket!" + Environment.NewLine;
                }
                if (!String.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show(error, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    error = "";
                }
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }

        private void Ujcikk_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            Reset.ClearAll(this);
        }
    }
}
