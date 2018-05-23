using System.ComponentModel;

namespace Laundry.Data.Models.Service
{
    public class ServiceModel
    {
        public int Service_ID { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("دسته بندی")]
        public string Category { get; set; }
        [DisplayName("هزینه")]
        public int Cost { get; set; }
    }
}