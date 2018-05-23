using System.ComponentModel;

namespace Laundry.Data.Models
{
    public class HumanModel
    {
        [DisplayName("نام")]
        public string FirstName { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayName("استان")]
        public string State { get; set; }
        [DisplayName("شهر")]
        public string City { get; set; }
        [DisplayName("خیابان")]
        public string Street { get; set; }
        [DisplayName("سایر")]
        public string Other { get; set; }
        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("تلفن")]
        public string Phone { get; set; }

    }
}