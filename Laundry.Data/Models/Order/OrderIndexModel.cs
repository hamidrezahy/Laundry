using System.Collections.Generic;

namespace Laundry.Data.Models.Order
{
    public class OrderIndexModel
    {
        public IEnumerable<OrderIndexRowModel> Orders { get; set; }
    }
}