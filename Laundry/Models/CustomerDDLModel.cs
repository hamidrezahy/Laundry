using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laundry.Models
{
    public class CustomerDDLModel
    {
        public string Phone { get; set; }
        public SelectList CustomerList { get; set; }
    }
}

