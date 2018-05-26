using System.Collections.Generic;
using Laundry.Data.Models.Service;

namespace Laundry.Data
{
    public interface IService
    {
        IEnumerable<ServiceIndexRowModel> GetServiceList();
        IEnumerable<ServiceIndexRowModel> GetByCategory(string category);
        ServiceModel Get(int id);
        bool Add(ServiceModel serviceModel);
        bool Remove(int id);
        // Service Edit(int id, Service service);
    }

}
