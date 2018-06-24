using Laundry.Data;
using Laundry.Data.Models.Service;
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
    public class ServiceController : Controller
    {
        private IService _service;
        private IConfiguration _configuration;
        private string dbString;

        public ServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbString = _configuration.GetConnectionString("LaundryConnection");
            _service = new ServiceService(dbString);

        }
        public IActionResult Index() =>
            View(new ServiceIndexModel()
            {
                WashServices = _service.GetByCategory("خشکشویی"),
                IronServices = _service.GetByCategory("اتوکشی")
            });

        public IActionResult Detail(int id)
        {
            return View(_service.Get(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            var genders = ServiceCategory.GetCategory().Select(x => new { Id = x, Value = x });

            CategoryDDLModel categoryDDLModel = new CategoryDDLModel
            {
                CategoryList = new SelectList(genders, "Id", "Value")
            };

            ViewData["categoryDDL"] = categoryDDLModel;


            return View();
        }

        [HttpPost]
        public IActionResult Add(ServiceModel serviceModel)
        {
            DateTime date = DateTime.Now;

            return _service.Add(serviceModel) ? Redirect("/Service/Index") : Redirect("/Home/AppError");
        }
        public IActionResult Delete(int id) => (_service.Remove(id)) ? Redirect("/Service/Index") : Redirect("/Home/AppError");

    }
}
