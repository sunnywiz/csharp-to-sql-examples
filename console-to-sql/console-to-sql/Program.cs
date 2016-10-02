using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_to_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("data source=(localdb)\\mssqllocaldb; database=StarWars"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select PersonId, Name, HeightInMeters from Person";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var personID = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            decimal? height;
                            if (reader.IsDBNull(2)) height = null; else  height = reader.GetDecimal(2);

                            Console.WriteLine("{0}: {1} {2}m", personID, name, height);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
