using Laundry.Data;
using Laundry.Data.Models.Customer;
using Laundry.Service.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Laundry.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer _customer;
        private IConfiguration _configuration;
        private string dbString;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbString = _configuration.GetConnectionString("LaundryConnection");
            _customer = new CustomerService(dbString);
        }
        public IActionResult Index() =>
            View(new CustomerIndexModel() { Customer = _customer.GetCustomerList() });
        public IActionResult Detail(string phone)
        {
            return View(_customer.Get(phone));
        }
        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(CustomerModel customerModel)
        {
            DateTime date = DateTime.Now;

            return _customer.Add(customerModel) ? Redirect("/Employee/Index") : Redirect("/Home/AppError");
        }
        public IActionResult Delete(string phone) => (_customer.Remove(phone)) ? Redirect("/Customer/Index") : Redirect("/Home/AppError");

    }
}