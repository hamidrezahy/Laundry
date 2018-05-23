using Laundry.Data;
using Laundry.Data.Models.Customer;
using Laundry.Data.Models.Order;
using Laundry.Models;
using Laundry.Service.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Laundry.Controllers
{
    public class OrderController : Controller
    {
        private IOrder _order;
        private IEmployee _employee;
        private ICustomer _customer;
        private IService _service;

        private IConfiguration _configuration;
        private string dbString;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbString = _configuration.GetConnectionString("LaundryConnection");
            _order = new OrderService(dbString);
            _employee = new EmployeeService(dbString);
            _customer = new CustomerService(dbString);
            _service = new ServiceService(dbString);
        }
        public IActionResult Index(string sort = "")
        {
            var orderIndexModel = _order.GetOrderList();

            if (sort == "date")
            {
                orderIndexModel.Orders = orderIndexModel.Orders.OrderBy(p => p.Date);
            }
            else if (sort == "datedesc")
            {
                orderIndexModel.Orders = orderIndexModel.Orders.OrderByDescending(p => p.Date);
            }

            return View(orderIndexModel);
        }

        public IActionResult Detail(int id)
        {
            return View(_order.Get(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            //var employees = _employee.GetEmployeeList().Employees.OrderBy(e => e.NCode).Select(x => new { Id = x.NCode, Value = x.FullName });
            var employees = _employee.GetEmployeeList().Employees.Select(x => new { Id = x.NCode, Value = x.FullName });
            var customers = _customer.GetCustomerList().Customer.Select(x => new { Id = x.Phone, Value = (x.FullName + " - " + x.Phone) });
            var services = _service.GetAll().Services.Select(x => new { Id = x.Service_ID, Value = (x.Category == "خشکشویی" ? x.Name + " => خشکشویی - " + x.Cost + " تومان" : x.Name + " => خشکشویی - " + x.Cost + " تومان") });

            EmployeeDDLModel employeeModel = new EmployeeDDLModel
            {
                EmployeeList = new SelectList(employees, "Id", "Value")
            };
            CustomerDDLModel customerModel = new CustomerDDLModel
            {
                CustomerList = new SelectList(customers, "Id", "Value")
            };
            ServiceDDLModel serviceModel = new ServiceDDLModel
            {
                ServiceList = new SelectList(services, "Id", "Value")
            };


            ViewData["EmpDDL"] = employeeModel;
            ViewData["CtmDDL"] = customerModel;
            ViewData["SrvDDL"] = serviceModel;

            return View();

        }

        [HttpPost]
        public IActionResult Add(OrderAddModel orderAddModel)
        {
            DateTime date = DateTime.Now;

            return _order.Add(new OrderModel
            {
                Name = orderAddModel.Name,
                Employee_NationalCode = orderAddModel.Employee_NationalCode,
                Customer_Phone = orderAddModel.Customer_Phone,
                Service_ID = orderAddModel.Service_ID,
                Date = date,
                DeliveryDate = date.AddDays(3),
                Cost = _service.Get(orderAddModel.Service_ID).Cost,
                Description = orderAddModel.Description

            }) ? Redirect("/order/Index") : Redirect("/Home/AppError");
        }

        [HttpGet]
        public IActionResult AddNC()
        {
            //var employees = _employee.GetEmployeeList().Employees.OrderBy(e => e.NCode).Select(x => new { Id = x.NCode, Value = x.FullName });
            var employees = _employee.GetEmployeeList().Employees.Select(x => new { Id = x.NCode, Value = x.FullName });
            var services = _service.GetAll().Services.Select(x => new { Id = x.Service_ID, Value = (x.Category == "خشکشویی" ? x.Name + " => خشکشویی - " + x.Cost + " تومان" : x.Name + " => خشکشویی - " + x.Cost + " تومان") });

            EmployeeDDLModel employeeModel = new EmployeeDDLModel
            {
                EmployeeList = new SelectList(employees, "Id", "Value")
            };
           
            ServiceDDLModel serviceModel = new ServiceDDLModel
            {
                ServiceList = new SelectList(services, "Id", "Value")
            };


            ViewData["EmpDDL"] = employeeModel;
            ViewData["SrvDDL"] = serviceModel;

            return View();

        }

        [HttpPost]
        public IActionResult AddNC(OrderAddNCModel orderAddNCModel)
        {
            DateTime date = DateTime.Now;

            return
            _customer.Add(new CustomerModel
            {
                FirstName = orderAddNCModel.Customer_FirstName,
                LastName = orderAddNCModel.Customer_LastName,
                Phone = orderAddNCModel.Customer_Phone,
                State = orderAddNCModel.Customer_State,
                City = orderAddNCModel.Customer_City,
                Street = orderAddNCModel.Customer_Street,
                Other = orderAddNCModel.Customer_Other
            }) ? _order.Add(new OrderModel
            {
                Name = orderAddNCModel.Name,
                Employee_NationalCode = orderAddNCModel.Employee_NationalCode,
                Customer_Phone = orderAddNCModel.Customer_Phone,
                Service_ID = orderAddNCModel.Service_ID,
                Date = date,
                DeliveryDate = date.AddDays(3),
                Cost = _service.Get(orderAddNCModel.Service_ID).Cost,
                Description = orderAddNCModel.Description

            }) ? Redirect("/order/Index") : Redirect("/Home/AppError") : Redirect("/Home/AppError");

        }

        public IActionResult Delete(int id) => (_order.Remove(id)) ? Redirect("/Order/Index") : Redirect("/Home/AppError");

    }
}
