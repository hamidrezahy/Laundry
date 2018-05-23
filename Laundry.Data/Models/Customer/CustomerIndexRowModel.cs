using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Laundry.Data.Models.Customer
{
    public class CustomerIndexRowModel
    {
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("تلفن")]
        public string Phone { get; set; }
    }
}
