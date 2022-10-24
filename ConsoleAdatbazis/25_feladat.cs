using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _25_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\n25. A rendelések összértéke alapján mi a vevők sorrendje?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(par * db) FROM vevo JOIN rendeles USING(vazon) JOIN tetel USING(razon) JOIN pizza USING(pazon) GROUP BY vnev ORDER BY SUM(par * db) DESC;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("vnev");
                        int fazon = dr.GetInt32("SUM(par * db)");

                        Console.WriteLine($"\n{fnev}\t{fazon}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
