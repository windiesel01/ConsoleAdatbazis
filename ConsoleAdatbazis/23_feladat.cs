using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _23_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\n23. Hány házhoz szállítása volt az egyes futároknak?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT fnev, COUNT(fazon) FROM futar JOIN rendeles USING(fazon) GROUP BY fnev;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("fnev");
                        int fazon = dr.GetInt32("COUNT(fazon)");

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
