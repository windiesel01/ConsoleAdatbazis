using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            bool TF = true;
            do
            {
                Console.Write("\nKérem adja meg a feladat sorszámát(23-28)" +
                    "\nHa befejezte akkor irjon be egy 0-t!" +
                    "\nA szám: ");
                int kerdesek = Convert.ToInt32(Console.ReadLine());
                switch (kerdesek)
                {
                    case 23:
                        _23_feladat.kerdesek(connection);
                        break;

                    case 24:
                        _24_feladat.kerdesek(connection);
                        break;

                    case 25:
                        _25_feladat.kerdesek(connection);
                        break;

                    case 26:
                        _26_feladat.kerdesek(connection);
                        break;

                    case 27:
                        _27_feladat.kerdesek(connection);
                        break;

                    case 28:
                        _28_feladat.kerdesek(connection);
                        break;

                    case 0:
                        TF = false;
                        break;
                }
            } while (TF);

            Console.ReadKey();
        }
    }
}
