using System.Collections.Generic;
using Laundry.Data.Models.Order;

namespace Laundry.Data
{
    public interface IOrder
    {
        OrderIndexModel GetOrderList();
        OrderIndexModel GetByCustomer(string customer);
        OrderIndexModel GetByEmployee(string employee);
        OrderIndexModel GetByService(int service);
        OrderDetailModel Get(int id);
        bool Add(OrderModel order);
        bool Remove(int id);
        // Order Edit(int id, Order order);
    }

}
