using Laundry.Data;
using Laundry.Data.Models.Customer;

namespace Laundry.Data
{
    public interface ICustomer
    {
        CustomerIndexModel GetCustomerList();
        CustomerIndexModel GetByState(string state);
        CustomerIndexModel GetByCity(string city);
        CustomerDetailModel Get(string phone);

        bool Add(CustomerModel customer);
        bool Remove(string phone);
        // Customer Edit(int id, Customer customer);
    }
}

