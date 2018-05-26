using Laundry.Data;
using Laundry.Data.Models.Employee;
using Laundry.Models;
using Laundry.Service.SqlServer;
using Laundry.Service.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Laundry.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee _employee;
        private IConfiguration _configuration;
        private string dbString;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbString = _configuration.GetConnectionString("LaundryConnection");
            _employee = new EmployeeService(dbString);
        }
        public IActionResult Index() =>
            View(new EmployeeIndexModel() { Employees = _employee.GetEmployeeList() });

        public IActionResult Detail(string nCode)
        {
            return View(_employee.Get(nCode));
        }
        [HttpGet]
        public IActionResult Add()
        {
            var genders = Gender.GetGetnders().Select(x => new { Id = x, Value = x });

            GenderDDLModel genderDDLModel = new GenderDDLModel
            {
                GenderList = new SelectList(genders, "Id", "Value")
            };

            ViewData["genderDDL"] = genderDDLModel;


            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeModel employeeModel)
        {
            DateTime date = DateTime.Now;

            return _employee.Add(employeeModel) ? Redirect("/Customer/Index") : Redirect("/Home/AppError");
        }
        public IActionResult Delete(string nCode) => (_employee.Remove(nCode)) ? Redirect("/Employee/Index") : Redirect("/Home/AppError");

    }
}