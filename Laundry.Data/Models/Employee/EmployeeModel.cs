using System.ComponentModel;

namespace Laundry.Data.Models.Employee
{
    public class EmployeeModel : HumanModel
    {
        [DisplayName("جنسیت")]
        public string Gender { get; set; }
        [DisplayName("حقوق")]
        public int Salary { get; set; }

        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("تلفن اضطراری")]
        public string EmergencyPhone { get; set; }

        [DisplayName("کد ملی")]
        public string NationalCode { get; set; }

    }
}