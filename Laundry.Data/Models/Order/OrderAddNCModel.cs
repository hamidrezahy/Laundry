using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Laundry.Data.Models.Order
{
    public class OrderAddNCModel
    {
        [DisplayName("نام")]
        public string Name { get; set; }

        [DisplayName("کارمند")]
        public string Employee_NationalCode { get; set; }

        [DisplayName("سرویس")]
        public int Service_ID { get; set; }

        [DisplayName("تاریخ تحویل")]
        public int AfterDate { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("نام")]
        public string Customer_FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        public string Customer_LastName { get; set; }

        [DisplayName("شماره تماس")]
        public string Customer_Phone { get; set; }

        [DisplayName("استان")]
        public string Customer_State { get; set; }

        [DisplayName("شهر")]
        public string Customer_City { get; set; }

        [DisplayName("خیابان")]
        public string Customer_Street { get; set; }

        [DisplayName("سایر")]
        public string Customer_Other { get; set; }
    }
}
