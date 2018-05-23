using System.Collections.Generic;
using Laundry.Data.Models.Employee;

namespace Laundry.Data
{
    public interface IEmployee
    {
        EmployeeIndexModel GetEmployeeList();
        EmployeeIndexModel GetByState(string state);
        EmployeeIndexModel GetByCity(string city);
        EmployeeIndexModel GetByGender(string gender);
        EmployeeDetailModel Get(string nCode);
        bool Add(EmployeeModel employee);
        bool Remove(string nCode);
        // Employee Edit(int id, Employee employee);
    }

}
