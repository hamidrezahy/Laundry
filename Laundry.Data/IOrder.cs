using System.Collections.Generic;
using Laundry.Data.Models.Order;

namespace Laundry.Data
{
    public interface IOrder
    {
        IEnumerable<OrderIndexRowModel> GetOrderList();
        IEnumerable<OrderIndexRowModel> GetByCustomer(string customer);
        IEnumerable<OrderIndexRowModel> GetByEmployee(string employee);
        IEnumerable<OrderIndexRowModel> GetByService(int service);
        OrderDetailModel Get(int id);
        bool Add(OrderModel order);
        bool Remove(int id);
        // Order Edit(int id, Order order);
    }

}
