using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _28_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\n28. Ki ette a legtöbb pizzát?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(db) FROM vevo JOIN rendeles USING(vazon) JOIN tetel USING (razon) GROUP BY vnev ORDER BY SUM(db) DESC LIMIT 1;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        int db = dr.GetInt32("SUM(db)");


                        Console.WriteLine($"\n{vnev}\t{db}");
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
