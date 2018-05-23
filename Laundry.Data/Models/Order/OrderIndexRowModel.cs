using System;

namespace Laundry.Data.Models.Order
{
    public class OrderIndexRowModel
    {
        public int Order_ID { get; set; }
        public string Employee { get; set; }
        public string Customer { get; set; }
        public string Service { get; set; }
        public string ServiceCategory { get; set; }

        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }
    }
}