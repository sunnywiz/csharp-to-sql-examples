using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_to_sql
{
    class PersonRepository
    {
        public static List<Person> GetAllPersons()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["StarWarsJediMindTrick"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select PersonId, Name, HeightInMeters from Person";
                    using (var reader = cmd.ExecuteReader())
                    {
                        var list = new List<Person>();
                        while (reader.Read())
                        {
                            var person = new Person()
                            {
                                PersonID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                HeightInMeters = (reader.IsDBNull(2))
                                ? (decimal?)null : reader.GetDecimal(2)
                            };
                            list.Add(person);
                        }
                        return list;
                    }
                }
            }

        }
    }
}
