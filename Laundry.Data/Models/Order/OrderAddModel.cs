using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Laundry.Data.Models.Order
{
    public  class OrderAddModel
    {
        [DisplayName("نام")]
        public string Name { get; set; }

        [DisplayName("کارمند")]
        public string Employee_NationalCode { get; set; }

        [DisplayName("مشتری")]
        public string Customer_Phone { get; set; }

        [DisplayName("سرویس")]
        public int Service_ID { get; set; }


        [DisplayName("تاریخ تحویل")]
        public int AfterDate { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }
    }
}
