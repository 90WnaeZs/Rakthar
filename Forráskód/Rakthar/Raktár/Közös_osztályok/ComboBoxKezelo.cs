using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raktár.Közös_osztályok
{
    public static class ComboBoxKezelo
    {
        public static void ComboBoxFeltoltes(Form f)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is ComboBox)
                    {
                        if (control.Name == "cikknev_combo")
                        {
                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                MySqlCommand cikk_comm = new MySqlCommand("Select Cikknév From cikk", mysqlcon);
                                MySqlDataReader cikk_reader = cikk_comm.ExecuteReader();
                                while (cikk_reader.Read())
                                {
                                    (control as ComboBox).Items.Add(cikk_reader.GetString("Cikknév"));
                                }
                                cikk_reader.Close();

                                mysqlcon.Close();
                            }
                        }
                        else if (control.Name == "gyartoi_combo")
                        {
                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                
                                MySqlCommand gyartoi_comm = new MySqlCommand("Select Gyártói From cikk", mysqlcon);
                                MySqlDataReader gyartoi_reader = gyartoi_comm.ExecuteReader();
                                while (gyartoi_reader.Read())
                                {
                                    (control as ComboBox).Items.Add(gyartoi_reader.GetString("Gyártói"));
                                }
                                gyartoi_reader.Close();

                                mysqlcon.Close();
                            }
                        }
                        else if (control.Name=="egyseg_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                MySqlCommand comm = new MySqlCommand("Select Megnevezés From mennyiseg", mysqlcon);
                                MySqlDataReader reader = comm.ExecuteReader();
                                while (reader.Read())
                                {
                                    (control as ComboBox).Items.Add(reader.GetString("Megnevezés"));
                                }
                                mysqlcon.Close();
                            }
                        }
                        else if(control.Name == "beszallito_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                MySqlDataAdapter besz = new MySqlDataAdapter("Select Beszállító_név From beszallito", mysqlcon);
                                DataTable dt = new DataTable();
                                besz.Fill(dt);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    (control as ComboBox).Items.Add(dt.Rows[i]["Beszállító_név"]);
                                }
                                mysqlcon.Close();
                            }
                        }
                        else if (control.Name == "tipus_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            (control as ComboBox).Items.Add("elektromos");
                            (control as ComboBox).Items.Add("mechanikus");
                            (control as ComboBox).Items.Add("rezsi");
                        }
                        else if (control.Name == "epulet_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            (control as ComboBox).Items.Add("1");
                            (control as ComboBox).Items.Add("2");
                            (control as ComboBox).Items.Add("3");
                        }
                        else if (control.Name == "raktar_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            (control as ComboBox).Items.Add("1");
                            (control as ComboBox).Items.Add("2");
                        }
                        else if (control.Name == "oszlop_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            for (int i = 1; i < 41; i++)
                            {
                                (control as ComboBox).Items.Add(i.ToString());
                            }
                        }
                        else if (control.Name == "polc_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            for (int i = 1; i < 7; i++)
                            {
                                (control as ComboBox).Items.Add(i.ToString());
                            }
                        }
                        else if (control.Name == "box_combo")
                        {
                            (control as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            for (int i = 1; i < 7; i++)
                            {
                                (control as ComboBox).Items.Add(i.ToString());
                            }
                        }
                        else if(control.Name == "gepnev_combo")
                        {
                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                MySqlCommand gepnev_comm = new MySqlCommand("Select Gépnév From gepek", mysqlcon);
                                MySqlDataReader gepnev_reader = gepnev_comm.ExecuteReader();
                                while (gepnev_reader.Read())
                                {
                                    (control as ComboBox).Items.Add(gepnev_reader.GetString("Gépnév"));
                                }
                                gepnev_reader.Close();

                                mysqlcon.Close();
                            }
                        }
                        else if (control.Name == "azonosito_combo")
                        {
                            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                            {
                                mysqlcon.Open();
                                
                                MySqlCommand azon_comm = new MySqlCommand("Select Azonosítószám From gepek", mysqlcon);
                                MySqlDataReader azon_reader = azon_comm.ExecuteReader();
                                while (azon_reader.Read())
                                {
                                    (control as ComboBox).Items.Add(azon_reader.GetString("Azonosítószám"));
                                }
                                azon_reader.Close();

                                mysqlcon.Close();
                            }
                        }
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };

            func(f.Controls);

        } // ComboBoxok feltöltése név alapján

        public static void ComboBoxSzűrtHelyFeltöltés(MySqlDataReader READER_SELECT_hely, ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box)
        {
            if (!epulet.Items.Contains(READER_SELECT_hely.GetString("Épület")))
            {
                epulet.Items.Add(READER_SELECT_hely.GetString("Épület"));
            }
            if (!raktar.Items.Contains(READER_SELECT_hely.GetString("Raktár")))
            {
                raktar.Items.Add(READER_SELECT_hely.GetString("Raktár"));
            }
            if (!oszlop.Items.Contains(READER_SELECT_hely.GetString("Oszlop")))
            {
                oszlop.Items.Add(READER_SELECT_hely.GetString("Oszlop"));
            }
            if (!polc.Items.Contains(READER_SELECT_hely.GetString("Polc")))
            {
                polc.Items.Add(READER_SELECT_hely.GetString("Polc"));
            }
            if (!box.Items.Contains(READER_SELECT_hely.GetString("Box")))
            {
                box.Items.Add(READER_SELECT_hely.GetString("Box"));
            }
        }

        public static void ComboBoxSpecialisFeltoltes(ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box, ComboBox cikk, ComboBox gyartoi)
        {
            epulet.Items.Clear();
            raktar.Items.Clear();
            oszlop.Items.Clear();
            polc.Items.Clear();
            box.Items.Clear();

            if(!String.IsNullOrWhiteSpace(cikk.Text) && !String.IsNullOrWhiteSpace(gyartoi.Text))
            {
                string str_cikkID = "";

                DataTable DT_SELECT_cikkID = new DataTable();

                string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév = @cikknev AND Gyártói=@gyartoi";
                string QUERY_SELECT_hely = "SELECT Épület, Raktár, Oszlop, Polc, Box FROM hely WHERE Cikk_ID=@cikkID";

                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                {
                    mysqlcon.Open();
                    CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikk.Text;
                    CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi.Text;
                    SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                    if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                    {
                        object resultObj = CMD_SELECT_cikkID.ExecuteScalar();
                        str_cikkID = resultObj.ToString();

                        using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
                        {
                            CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);

                            MySqlDataReader hely_reader = CMD_SELECT_hely.ExecuteReader();

                            while (hely_reader.Read())
                            {
                                if (!epulet.Items.Contains(hely_reader.GetString("Épület")))
                                {
                                    epulet.Items.Add(hely_reader.GetString("Épület"));
                                }
                                if (!raktar.Items.Contains(hely_reader.GetString("Raktár")))
                                {
                                    raktar.Items.Add(hely_reader.GetString("Raktár"));
                                }
                                if (!oszlop.Items.Contains(hely_reader.GetString("Oszlop")))
                                {
                                    oszlop.Items.Add(hely_reader.GetString("Oszlop"));
                                }
                                if (!polc.Items.Contains(hely_reader.GetString("Polc")))
                                {
                                    polc.Items.Add(hely_reader.GetString("Polc"));
                                }
                                if (!box.Items.Contains(hely_reader.GetString("Box")))
                                {
                                    box.Items.Add(hely_reader.GetString("Box"));
                                }
                            }
                            hely_reader.Close();

                            mysqlcon.Close();
                        }
                    }
                }
            }
        }

        public static void Gepnev_Azonosito_Feltoltes(ComboBox gepnev, ComboBox azonosito)
        {
            using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
            {
                mysqlcon.Open();
                MySqlCommand gepnev_comm = new MySqlCommand("Select Gépnév From gepek", mysqlcon);
                MySqlDataReader gepnev_reader = gepnev_comm.ExecuteReader();
                while (gepnev_reader.Read())
                {
                    gepnev.Items.Add(gepnev_reader.GetString("Gépnév"));
                }
                gepnev_reader.Close();

                MySqlCommand azon_comm = new MySqlCommand("Select Azonosítószám From gepek", mysqlcon);
                MySqlDataReader azon_reader = azon_comm.ExecuteReader();
                while (azon_reader.Read())
                {
                    azonosito.Items.Add(azon_reader.GetString("Azonosítószám"));
                }
                azon_reader.Close();

                mysqlcon.Close();
            }
        }

        public static void Cikknev_GyartoiSzambol(ComboBox cikk, ComboBox gyartoi)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                {
                    mysqlcon.Open();

                    MySqlDataAdapter cikk_adapter = new MySqlDataAdapter("Select Cikknév From cikk Where Gyártói='" + gyartoi.Text + "'", mysqlcon);
                    DataTable dt1 = new DataTable();
                    cikk_adapter.Fill(dt1);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Object cellValue = dt1.Rows[0][0];

                            cikk.Text = cellValue.ToString();
                        }
                        else if (dt1.Rows.Count == 0)
                        {
                            MessageBox.Show("Nincs ilyen gyártói szám!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Váratlan hiba!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Gyartoi_Cikknevbol(ComboBox cikk_CB, ComboBox gyartoi_CB)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                {
                    mysqlcon.Open();

                    MySqlDataAdapter gyartoi = new MySqlDataAdapter("Select Gyártói From cikk Where Cikknév='" + cikk_CB.Text + "'", mysqlcon);
                    DataTable dt1 = new DataTable();
                    gyartoi.Fill(dt1);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Object cellValue = dt1.Rows[0][0];

                            gyartoi_CB.Text = cellValue.ToString();
                        }
                        else if (dt1.Rows.Count == 0)
                        {
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Váratlan hiba!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Gepnev_Azonositobol(ComboBox gepnev_CB, ComboBox azonosito_CB)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                {
                    mysqlcon.Open();

                    MySqlDataAdapter gyartoi = new MySqlDataAdapter("Select Gépnév From gepek Where Azonosítószám='" + azonosito_CB.Text + "'", mysqlcon);
                    DataTable dt1 = new DataTable();
                    gyartoi.Fill(dt1);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Object cellValue = dt1.Rows[0][0];

                            gepnev_CB.Text = cellValue.ToString();
                        }
                        else if (dt1.Rows.Count == 0)
                        {
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Váratlan hiba!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Azonosito_Gepnevbol(ComboBox gepnev_CB, ComboBox azonosito_CB)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                {
                    mysqlcon.Open();

                    MySqlDataAdapter gyartoi = new MySqlDataAdapter("Select Azonosítószám From gepek Where Gépnév='" + gepnev_CB.Text + "'", mysqlcon);
                    DataTable dt1 = new DataTable();
                    gyartoi.Fill(dt1);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Object cellValue = dt1.Rows[0][0];

                            azonosito_CB.Text = cellValue.ToString();
                        }
                        else if (dt1.Rows.Count == 0)
                        {
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Váratlan hiba!");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void ClearComboBoxItems(Form f)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is ComboBox)
                    {
                        if(control.Name=="epulet_combo" || control.Name=="raktar_combo" || control.Name == "oszlop_combo" || control.Name == "polc_combo" || control.Name == "box_combo")
                        {
                            if (String.IsNullOrWhiteSpace(control.Text))
                            {
                                (control as ComboBox).Items.Clear();
                            }
                        }
                    }
                    else
                    {
                        func(control.Controls);
                    }
            };

            func(f.Controls);
        }

        public static void ClearListItems(ComboBox combo)
        {
            string combo_text = combo.Text;
            combo.Items.Clear();
            combo.Text=combo_text;
        }

        public static void Epulet_Szures(ComboBox cikknev, ComboBox gyartoi, ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box)
        {
            try
            {
                if(!String.IsNullOrWhiteSpace(epulet.Text))
                {
                    bool van_cikk = false;

                    string str_cikkID = "";

                    DataTable DT_SELECT_cikkID = new DataTable();

                    string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                    string QUERY_SELECT_hely = "SELECT Épület,Raktár,Oszlop,Polc,Box FROM hely WHERE Cikk_ID=@cikkID AND Épület=@epulet";
                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                    using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_hely = new MySqlDataAdapter(CMD_SELECT_hely))
                    {
                        mysqlcon.Open();
                        CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);

                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                            str_cikkID = cikkID_row["ID_Cikk"].ToString();
                            van_cikk = true;

                            if (van_cikk)
                            {
                                CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                                CMD_SELECT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                                MySqlDataReader READER_SELECT_hely = CMD_SELECT_hely.ExecuteReader();

                                while (READER_SELECT_hely.Read())
                                {
                                    ComboBoxSzűrtHelyFeltöltés(READER_SELECT_hely, epulet, raktar, oszlop, polc, box);
                                }
                                READER_SELECT_hely.Close();
                            }
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            van_cikk = false;
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Raktar_Szures(ComboBox cikknev, ComboBox gyartoi, ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box)
        {
            try
            {
                if(!String.IsNullOrWhiteSpace(epulet.Text) && !String.IsNullOrWhiteSpace(raktar.Text))
                {
                    bool van_cikk = false;

                    string str_cikkID = "";

                    DataTable DT_SELECT_cikkID = new DataTable();

                    string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                    string QUERY_SELECT_hely = "SELECT Épület,Raktár,Oszlop,Polc,Box FROM hely WHERE Cikk_ID=@cikkID AND Épület=@epulet AND Raktár=@raktar";
                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                    using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_hely = new MySqlDataAdapter(CMD_SELECT_hely))
                    {
                        mysqlcon.Open();
                        CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);

                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                            str_cikkID = cikkID_row["ID_Cikk"].ToString();
                            van_cikk = true;

                            if (van_cikk)
                            {
                                CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                                CMD_SELECT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                                CMD_SELECT_hely.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);
                                MySqlDataReader READER_SELECT_hely = CMD_SELECT_hely.ExecuteReader();

                                while (READER_SELECT_hely.Read())
                                {
                                    ComboBoxSzűrtHelyFeltöltés(READER_SELECT_hely, epulet, raktar, oszlop, polc, box);
                                }
                                READER_SELECT_hely.Close();
                            }
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            van_cikk = false;
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        public static void Oszlop_Szures(ComboBox cikknev, ComboBox gyartoi, ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box)
        {
            try
            {
                if(!String.IsNullOrWhiteSpace(epulet.Text) && !String.IsNullOrWhiteSpace(raktar.Text) && !String.IsNullOrWhiteSpace(oszlop.Text))
                {
                    bool van_cikk = false;

                    string str_cikkID = "";

                    DataTable DT_SELECT_cikkID = new DataTable();

                    string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                    string QUERY_SELECT_hely = "SELECT Épület,Raktár,Oszlop,Polc,Box FROM hely WHERE Cikk_ID=@cikkID AND Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop";
                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                    using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_hely = new MySqlDataAdapter(CMD_SELECT_hely))
                    {
                        mysqlcon.Open();
                        CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop.Text);

                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                            str_cikkID = cikkID_row["ID_Cikk"].ToString();
                            van_cikk = true;

                            if (van_cikk)
                            {
                                CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                                CMD_SELECT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                                CMD_SELECT_hely.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);
                                CMD_SELECT_hely.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop.Text);

                                MySqlDataReader READER_SELECT_hely = CMD_SELECT_hely.ExecuteReader();

                                while (READER_SELECT_hely.Read())
                                {
                                    ComboBoxSzűrtHelyFeltöltés(READER_SELECT_hely, epulet, raktar, oszlop, polc, box);
                                }
                                READER_SELECT_hely.Close();
                            }
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            van_cikk = false;
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        public static void Polc_Szures(ComboBox cikknev, ComboBox gyartoi, ComboBox epulet, ComboBox raktar, ComboBox oszlop, ComboBox polc, ComboBox box)
        {
            try
            {
                if(!String.IsNullOrWhiteSpace(epulet.Text) && !String.IsNullOrWhiteSpace(raktar.Text) && !String.IsNullOrWhiteSpace(oszlop.Text) && !String.IsNullOrWhiteSpace(polc.Text))
                {
                    bool van_cikk = false;

                    string str_cikkID = "";

                    DataTable DT_SELECT_cikkID = new DataTable();

                    string QUERY_SELECT_cikkID = "SELECT ID_Cikk FROM cikk WHERE Cikknév=@cikknev AND Gyártói=@gyartoi";
                    string QUERY_SELECT_hely = "SELECT Épület,Raktár,Oszlop,Polc,Box FROM hely WHERE Cikk_ID=@cikkID AND Épület=@epulet AND Raktár=@raktar AND Oszlop=@oszlop AND Polc=@polc";
                    using (MySqlConnection mysqlcon = new MySqlConnection(Ipcim.constr))
                    using (MySqlCommand CMD_SELECT_cikkID = new MySqlCommand(QUERY_SELECT_cikkID, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_cikkID = new MySqlDataAdapter(CMD_SELECT_cikkID))
                    using (MySqlCommand CMD_SELECT_hely = new MySqlCommand(QUERY_SELECT_hely, mysqlcon))
                    using (MySqlDataAdapter SDA_SELECT_hely = new MySqlDataAdapter(CMD_SELECT_hely))
                    {
                        mysqlcon.Open();
                        CMD_SELECT_cikkID.Parameters.Add("@cikknev", MySqlDbType.String).Value = cikknev.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@gyartoi", MySqlDbType.String).Value = gyartoi.Text;
                        CMD_SELECT_cikkID.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop.Text);
                        CMD_SELECT_cikkID.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc.Text);

                        SDA_SELECT_cikkID.Fill(DT_SELECT_cikkID);

                        if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count > 0)
                        {
                            DataRow cikkID_row = DT_SELECT_cikkID.Rows[0];
                            str_cikkID = cikkID_row["ID_Cikk"].ToString();
                            van_cikk = true;

                            if (van_cikk)
                            {
                                CMD_SELECT_hely.Parameters.Add("@cikkID", MySqlDbType.Int32).Value = Convert.ToInt32(str_cikkID);
                                CMD_SELECT_hely.Parameters.Add("@epulet", MySqlDbType.Int32).Value = Convert.ToInt32(epulet.Text);
                                CMD_SELECT_hely.Parameters.Add("@raktar", MySqlDbType.Int32).Value = Convert.ToInt32(raktar.Text);
                                CMD_SELECT_hely.Parameters.Add("@oszlop", MySqlDbType.Int32).Value = Convert.ToInt32(oszlop.Text);
                                CMD_SELECT_hely.Parameters.Add("@polc", MySqlDbType.Int32).Value = Convert.ToInt32(polc.Text);

                                MySqlDataReader READER_SELECT_hely = CMD_SELECT_hely.ExecuteReader();

                                while (READER_SELECT_hely.Read())
                                {
                                    ComboBoxSzűrtHelyFeltöltés(READER_SELECT_hely, epulet, raktar, oszlop, polc, box);
                                }
                                READER_SELECT_hely.Close();
                            }
                        }
                        else if (DT_SELECT_cikkID != null && DT_SELECT_cikkID.Rows.Count == 0)
                        {
                            van_cikk = false;
                            MessageBox.Show("Nincs ilyen cikk!");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
    }
}
