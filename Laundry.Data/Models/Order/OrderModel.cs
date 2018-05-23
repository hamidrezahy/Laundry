using System;

namespace Laundry.Data.Models.Order
{
    public class OrderModel
    {
        public int Order_ID { get; set; }
        public string Employee_NationalCode { get; set; }
        public string Customer_Phone { get; set; }
        public int Service_ID { get; set; }

        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }


    }
}