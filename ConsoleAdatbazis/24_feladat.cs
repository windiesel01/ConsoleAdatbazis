using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class _24_feladat
    {
        public static void kerdesek(MySqlConnection connection)
        {
            Console.WriteLine("\nA fogyasztás alapján mi a pizzák népszerűségi sorrendje?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT pnev, SUM(db) FROM pizza JOIN tetel USING(pazon) GROUP BY pnev ORDER BY SUM(db) DESC;";
                //-- adatok lekérdezés
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string pnev = dr.GetString("pnev");
                        int db = dr.GetInt32("SUM(db)");

                        Console.WriteLine($"\n{pnev}\t{db}");
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
