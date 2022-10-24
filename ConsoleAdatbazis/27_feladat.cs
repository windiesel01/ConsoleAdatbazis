using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _27_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\n27. Ki szállította házhoz a legtöbb pizzát?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT fnev, SUM(db) FROM futar JOIN rendeles USING(fazon) JOIN tetel USING (razon) GROUP BY fnev ORDER BY SUM(db) DESC LIMIT 1;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("fnev");
                        int db = dr.GetInt32("SUM(db)");


                        Console.WriteLine($"\n{fnev}\t{db}");
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
