namespace EmployeesDB.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeesDB.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public static List<EmployeeRecord> LoadEmployeesFromCSV(string filename)
        {
            var employees = new List<EmployeeRecord>();
            using (var sr = new StreamReader(filename))
            {
                // Skip headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var items = line.Split(';');
                    employees.Add(new EmployeeRecord
                    {
                        Name = items[0],
                        BirthDate = DateTime.ParseExact(items[1], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        Position = items[2],
                        Salary = decimal.Parse(items[3]),
                        SupervisorName = items[4]
                    });
                }
            }
            return employees;
        }

        protected override void Seed(EmployeesDB.Context context)
        {
            string s = @"C:\Users\student\Desktop\Новая папка\hw04_1\EmployeesDB\EmployeesDB\source.csv";
            List<EmployeeRecord> list = LoadEmployeesFromCSV(s);

            foreach (var item in list)
            {
                context.Positions.AddOrUpdate(
                    p => p.Name,
                    new Position {Name = item.Position, Salary = item.Salary}
                );
            }

            context.SaveChanges();

            foreach (var item in list)
            {
                var superVisor = context.Employees
                    .Single(l => l.Name.Equals(item.SupervisorName));

                var position = context.Positions
                    .Single(z => z.Name.Equals(item.Position));
             
                context.Employees.AddOrUpdate(
                    e => e.Name,
                    new Employee { Name = item.Name, Position = position, Supervisor = superVisor}
                );
            }

            context.SaveChanges();
        }
    }
}
