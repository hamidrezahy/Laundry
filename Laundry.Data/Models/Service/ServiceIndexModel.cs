using System.Collections.Generic;

namespace Laundry.Data.Models.Service
{
    public class ServiceIndexModel
    {
        public IEnumerable<ServiceIndexRowModel> WashServices { get; set; }
        public IEnumerable<ServiceIndexRowModel> IronServices { get; set; }
    }
}
