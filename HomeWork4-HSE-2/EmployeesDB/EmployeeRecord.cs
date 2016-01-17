using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB
{
    class EmployeeRecord
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string SupervisorName { get; set; }
    }
}
