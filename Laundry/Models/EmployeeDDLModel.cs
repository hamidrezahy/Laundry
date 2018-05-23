using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laundry.Models
{
    public class EmployeeDDLModel
    {
        public string NCode { get; set; }
        public SelectList EmployeeList { get; set; }
    }
}

