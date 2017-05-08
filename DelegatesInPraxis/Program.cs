using System;
using System.Collections.Generic;

namespace DelegatesInPraxis
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            var query = Abfrage(employees, 5);

            foreach (var e in query)
            {
                Console.WriteLine($"{e.Id} - {e.Name, 10} - {e.Experience}");
            }
            Console.ReadKey();
        }

        private static IEnumerable<Employee> Abfrage(
            IEnumerable<Employee> employees,
            int expreience)
        {
            foreach (var e in employees)
                if (e.Experience < expreience)
                    yield return e;
        }

        private static IEnumerable<Employee> GetData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Hans", Experience = 5 },
                new Employee { Id = 2, Name = "Lisa", Experience = 15 },
                new Employee { Id = 3, Name = "Franz", Experience = 4 },
                new Employee { Id = 4, Name = "Stanislaus", Experience = 9 },
                new Employee { Id = 5, Name = "Thomas", Experience = 14 },
                new Employee { Id = 6, Name = "Luisa", Experience = 2 },
                new Employee { Id = 7, Name = "Antonia", Experience = 13 },
                new Employee { Id = 8, Name = "Sepp", Experience = 10 },
                new Employee { Id = 9, Name = "Alexandra", Experience = 8 },
            };
        }
    }
}
