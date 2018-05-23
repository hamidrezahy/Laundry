using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laundry.Models
{
    public class CategoryDDLModel
    {
        public string Category { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
