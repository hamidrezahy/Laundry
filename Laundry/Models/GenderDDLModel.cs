using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laundry.Models
{
    public class GenderDDLModel
    {
        public string Gender { get; set; }
        public SelectList GenderList { get; set; }
    }
}
