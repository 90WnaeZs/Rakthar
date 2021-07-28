using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raktár
{
    class Adatbazis
    {
        public static MySqlConnection mysqlcon;
        public static MySqlCommand cmd;
        public static DataTable dt;
        public static MySqlDataAdapter adapter;
        public static DataTable table;

        public static string cikk_query =
                "SELECT cikk.Cikknév,cikk.Gyártói,cikk.Típus,cikk.Ár AS Ár_Forint" +
                ",hely.Mennyiség,mennyiseg.Egység,beszallito.Beszállító_név AS Beszállító" +
                ",cikk.Minimum,cikk.Maximum," +
                "hely.Épület,hely.Raktár,hely.Oszlop,hely.Polc,hely.Box " +
                "FROM cikk " +
                "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség " +
                "JOIN beszallito ON cikk.Beszállító_ID=beszallito.ID_Beszállító " +
                "JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID ";

        public static string rendeles_query = "SELECT cikk.Cikknév,cikk.Gyártói,rendeles.Mennyiség,mennyiseg.Egység" +
            ",beszallito.Beszállító_név AS Beszállító" +
            ",rendeles.Rendelve,rendeles.Érkezés " +
            "FROM rendeles JOIN cikk ON rendeles.Cikk_ID=cikk.ID_Cikk " +
            "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség " +
            "JOIN beszallito ON rendeles.Beszállító_ID=beszallito.ID_Beszállító ";

        public static string karb_query = "SELECT gepek.Gépnév,gepek.Azonosítószám,cikk.Cikknév,karbantartas.Mennyiség,mennyiseg.Egység" +
            ",karbantartas.Karbantartva,karbantartas.Karbantartó " +
            "FROM karbantartas " +
            "JOIN gepek ON karbantartas.Gép_ID=gepek.ID_Gép " +
            "JOIN cikk ON karbantartas.Cikk_ID=cikk.ID_Cikk " +
            "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség ";

        public static string hely_query =
                "SELECT cikk.Cikknév,cikk.Gyártói,cikk.Típus,cikk.Ár AS Ár_Forint" +
                ",hely.Mennyiség,mennyiseg.Egység" +
                ",cikk.Minimum,cikk.Maximum," +
                "hely.Épület,hely.Raktár,hely.Oszlop,hely.Polc,hely.Box " +
                "FROM cikk " +
                "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség " +
                "JOIN beszallito ON cikk.Beszállító_ID=beszallito.ID_Beszállító " +
                "JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID ";

        public static string utemezett_query =
                "SELECT gepek.Gépnév,gepek.Azonosítószám,utemezes.Dátum,utemezes.Óra" +
                " FROM gepek " +
                "JOIN utemezes ON gepek.ID_Gép=utemezes.Gép_ID ";

        public static string selejtezes_query =
                "SELECT cikk.Cikknév,cikk.Gyártói,selejtezes.Mennyiség,selejtezes.Dátum,selejtezes.Indok" +
                " FROM selejtezes " +
                "JOIN cikk ON selejtezes.Cikk_ID=cikk.ID_cikk ";

        public static string beszallito_query = "SELECT Beszállító_név, Szállítási_idő, Város, Cím, Telefonszám, Emailcím FROM beszallito ";

        public static string min_query = "SELECT cikk.Cikknév,cikk.Gyártói,cikk.Típus,cikk.Ár AS Ár_Forint" +
                ",hely.Mennyiség,mennyiseg.Egység" +
                ",cikk.Minimum,cikk.Maximum," +
                "hely.Épület,hely.Raktár,hely.Oszlop,hely.Polc,hely.Box " +
                "FROM cikk " +
                "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség " +
                "JOIN beszallito ON cikk.Beszállító_ID=beszallito.ID_Beszállító " +
                "JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID " +
                "WHERE hely.Mennyiség<=cikk.Minimum ";

        public static string search_min_query = "SELECT cikk.Cikknév,cikk.Gyártói,cikk.Típus,cikk.Ár AS Ár_Forint" +
                ",hely.Mennyiség,mennyiseg.Egység" +
                ",cikk.Minimum,cikk.Maximum," +
                "hely.Épület,hely.Raktár,hely.Oszlop,hely.Polc,hely.Box " +
                "FROM cikk " +
                "JOIN mennyiseg ON cikk.Mennyiség_ID=mennyiseg.ID_Mennyiség " +
                "JOIN beszallito ON cikk.Beszállító_ID=beszallito.ID_Beszállító " +
                "JOIN hely ON cikk.ID_Cikk=hely.Cikk_ID " +
                "WHERE hely.Mennyiség<=cikk.Minimum ";


        public static void MYSQL_methods(string query)
        {
            /*var dt = new DataTable(); ;

            using (var mysqlcon = new MySqlConnection(Ipcim.constr))
            using (var cmd = new MySqlCommand(query, mysqlcon))
            using (var sda = new MySqlDataAdapter(cmd))
            {
                try
                {
                    mysqlcon.Open();
                    sda.Fill(dt);
                    mysqlcon.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                
            }*/
            using (mysqlcon = new MySqlConnection(Ipcim.constr))
            {
                try
                {
                    mysqlcon.Open();
                    dt = new DataTable();
                    dt.Clear();
                    adapter = new MySqlDataAdapter(query, mysqlcon);
                    table = new DataTable();
                    adapter.Fill(table);
                    mysqlcon.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                
            }
        }
        public static string Query(string query) // lekérdezés eltárolása egy változóba
        {
            try
            {
                    using (mysqlcon = new MySqlConnection(Ipcim.constr))
                    {
                    /*string x = "";
                    mysqlcon.Open();
                    cmd = new MySqlCommand(query, mysqlcon);
                    x = cmd.ExecuteScalar().ToString();
                    mysqlcon.Close();

                    return x;*/

                    string resultStr="";
                    mysqlcon.Open();
                    cmd = new MySqlCommand(query,mysqlcon);
                    
                    object resultObj = cmd.ExecuteScalar();

                    if (resultObj != null)
                    {
                        resultStr = resultObj.ToString();
                        return Convert.ToString(resultStr);
                    }
                    return Convert.ToString(resultStr);
                    }
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

    }
}
