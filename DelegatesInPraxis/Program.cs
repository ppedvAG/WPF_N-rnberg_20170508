using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    public delegate bool MyDelegate(Employee e);
    // Action       -> void
    // Predicate<>  -> bool
    // Func

    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedingung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedingung);
            //var del = new Func<Employee, bool>(Bedingung);
            //Func<Employee, bool> del = Bedingung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Id < 5;
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Id < 5;
            //});

            //var query = Abfrage(employees, (e) => e.Id < 5);
            var query = employees.Abfrage(e => e.Id < 5);
            var linqQuery = employees.Where(e => e.Experience > 10);
            var linqQuery1 = from e in employees
                             where e.Experience > 10
                             select e;

            foreach (var e in query)
            {
                Console.WriteLine($"{e.Id} - {e.Name, 10} - {e.Experience}");
            }

            var namen = new[] { "Franz", "Luis", "Sepp" };
            var gefiltert = MyExtentions.Abfrage(namen, n => n.StartsWith("L"));
            var gefiltert2 = namen.Abfrage(n => n.StartsWith("L"));


            Console.ReadKey();
        }

        private static bool Bedingung(Employee e)
        {
            return e.Name.Contains("z");
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

    public static class MyExtentions
    {
        public static IEnumerable<T> Abfrage<T>(
            this IEnumerable<T> collection,
            Func<T, bool> predicate)
        {
            foreach (var c in collection)
                if (predicate(c))
                    yield return c;
        }
    }
}
