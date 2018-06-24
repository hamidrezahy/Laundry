using System.Collections.Generic;
using Laundry.Data.Models.Employee;

namespace Laundry.Data
{
    public interface IEmployee
    {
        IEnumerable<EmployeeIndexRowModel> GetEmployeeList();
        IEnumerable<EmployeeIndexRowModel> GetByState(string state);
        IEnumerable<EmployeeIndexRowModel> GetByCity(string city);
        IEnumerable<EmployeeIndexRowModel> GetByGender(string gender);
        EmployeeDetailModel Get(string nCode);
        bool Add(EmployeeModel employee);
        bool Remove(string nCode);
        // Employee Edit(int id, Employee employee);
    }

}
