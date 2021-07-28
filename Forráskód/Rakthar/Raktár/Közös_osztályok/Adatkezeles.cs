using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raktár.Közös_osztályok
{
    class Adatkezeles
    {
        // Kiválasztott tábla betöltése a DataGridViewba, NINCS felhasználó által beírt érték
        public static void MYSQL_lekerdezes(string query, DataGridView dgv) 
        {
            Adatbazis.MYSQL_methods(query);
            dgv.DataSource = Adatbazis.table;
            dgv.Refresh();

            if (dgv.DataSource == null)
            {
                MySqlDataAdapter sda2 = new MySqlDataAdapter(query, Adatbazis.mysqlcon);
                sda2.Fill(Adatbazis.dt);
                dgv.DataSource = Adatbazis.dt;
            }
        }

        // Speciális keresés a keresőmezővel, annak megfelelő adatbetöltés a DataGridViewba, VAN bevitt érték
        public static void datagrid_STRINGparam(string query,DataGridView dgv,string searchvalue) 
        {
            var result = new DataTable();

            string sql = query;

            using (var con = new MySqlConnection(Ipcim.constr))
            using (var cmd = new MySqlCommand(sql, con))
            using (var sda = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@search", MySqlDbType.String).Value = searchvalue;

                sda.Fill(result);
            }
            dgv.DataSource = result;
        }

        public static void datagrid_INTparam(string query, DataGridView dgv, string searchvalue)
        {
            var result = new DataTable();

            string sql = query;

            using (var con = new MySqlConnection(Ipcim.constr))
            using (var cmd = new MySqlCommand(sql, con))
            using (var sda = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@search", MySqlDbType.Int32).Value = Convert.ToInt32(searchvalue);

                sda.Fill(result);
            }
            dgv.DataSource = result;
        }
    }
}
