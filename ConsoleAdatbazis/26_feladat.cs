using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _26_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\n26. Melyik a legdrágább pizza?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(par) FROM pizza;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string max = dr.GetString("MAX(par)");


                        Console.WriteLine($"\n{max}");
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
