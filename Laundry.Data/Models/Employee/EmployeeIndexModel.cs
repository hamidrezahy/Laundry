using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry.Data.Models.Employee
{
    public class EmployeeIndexModel
    {
        public IEnumerable<EmployeeIndexRowModel> Employees { get; set; }
    }
}
