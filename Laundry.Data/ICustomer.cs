using Laundry.Data;
using Laundry.Data.Models.Customer;
using System.Collections.Generic;

namespace Laundry.Data
{
    public interface ICustomer
    {
        IEnumerable<CustomerIndexRowModel> GetCustomerList();
        IEnumerable<CustomerIndexRowModel> GetByState(string state);
        IEnumerable<CustomerIndexRowModel> GetByCity(string city);
        CustomerDetailModel Get(string phone);

        bool Add(CustomerModel customer);
        bool Remove(string phone);
        // Customer Edit(int id, Customer customer);
    }
}

