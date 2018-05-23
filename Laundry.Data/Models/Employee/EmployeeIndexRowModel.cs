using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Laundry.Data.Models.Employee
{
    public class EmployeeIndexRowModel
    {
        [DisplayName("شماره ملی")]
        public string NCode { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }
        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("تلفن")]
        public string Phone { get; set; }
        [DisplayName("جنسیت")]
        public string Gender { get; set; }
        [DisplayName("حقوق")]
        public int Salary { get; set; }

    }
}