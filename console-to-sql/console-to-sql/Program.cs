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
            var persons = PersonRepository.GetAllPersons();
            foreach (var person in persons)
            {
                Console.WriteLine("{0}: {1} {2}m",
                    person.PersonID,
                    person.Name,
                    person.HeightInMeters);

            }
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }

    }
}
