using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laundry.Models
{
    public class ServiceDDLModel
    {
        public string ID { get; set; }
        public SelectList ServiceList { get; set; }
    }
}

