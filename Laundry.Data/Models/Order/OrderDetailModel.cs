using System;
using System.ComponentModel;

namespace Laundry.Data.Models.Order
{
    public class OrderDetailModel
    {
        [DisplayName("کد سفارش")]
        public int Order_ID { get; set; }

        [DisplayName("نام")]
        public string Name { get; set; }

        [DisplayName("نام کارمند")]
        public string Employee { get; set; }

        [DisplayName("تلفن کارمند")]
        public string EmployeePhone { get; set; }
        [DisplayName("تلفن اضطراری کارمند")]
        public string EmployeeEmergencyPhone { get; set; }

        [DisplayName("نام مشتری")]
        public string Customer { get; set; }
        [DisplayName("تلفن مشتری")]
        public string CustomerPhone { get; set; }
        [DisplayName("آدرس مشتری")]
        public string CustomerAddress { get; set; }

        [DisplayName("سرویس")]
        public string Service { get; set; }
        [DisplayName("دسته بندی")]
        public string ServiceCategory { get; set; }

        [DisplayName("تاریخ دریافت سفارش")]
        public DateTime Date { get; set; }
        [DisplayName("تاریخ تحویل")]
        public DateTime DeliveryDate { get; set; }


        [DisplayName("هزینه")]
        public int Cost { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

    }
}