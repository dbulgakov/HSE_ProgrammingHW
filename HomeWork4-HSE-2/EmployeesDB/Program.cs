using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeesDB
{
    class Program
    {   
        // Change salary of all employees holding the specified position by delta
        static void ChangeSalary(Context context, string position, decimal delta)
        {
            var selectedEmployees = context.Employees
                .Where(m => m.Position.Equals(position));

            foreach (var pos in selectedEmployees)
	        {
                pos.Position.Salary += delta;
	        }
        }

        // Remove all employees occupying the specified position and the position itself
        static void RemovePosition(Context context, string position)
        {
            var s = context.Positions
                .Where(m => m.Name.Equals(position));
            foreach (var item in s)
            {
                context.Positions.Remove(item);
            }
        }

        // Calculate average salary of employees having the specified supervisor
        static decimal AverageSalary(Context context, string supervisor)
        {
            var avg = context.Employees
                .Where(m => m.Supervisor.Name.Equals(supervisor));

            return avg.Average(m => m.Position.Salary);
        }
        
        

        static IQueryable<EmployeeRecord> LoadEmployeesFromDB(Context context)
        {
            throw new NotImplementedException();
        }   

        static void ShowEmployees(IEnumerable<EmployeeRecord> employees)
        {
            Console.WriteLine("|{0,-17}|{1,-10}|{2,-22}|{3,-7}|{4,-17}|", "Name", "Birth date", "Position", "Salary", "Supervisor");
            foreach (var item in employees)
            {
                Console.WriteLine("|{0,-17}|{1,-10}|{2,-22}|{3,-7}|{4,-17}|", item.Name, 
                    item.BirthDate.ToShortDateString(),
                    item.Position, item.Salary, item.SupervisorName);
            }
        }

        static void Main(string[] args)
        {
            using (var c = new Context())
            {
                ChangeSalary(c, "Engineer", 3000);
                c.Employees.ToList();
                c.SaveChanges();
            }

            //ShowEmployees(data);
        }
    }
}
