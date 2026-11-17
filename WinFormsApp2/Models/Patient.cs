using System;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید 10 رقم باشد.")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "نام الزامی است.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "شماره تلفن الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تلفن باید 11 رقم و با 09 شروع شود.")]
        public string Phone { get; set; }

        [StringLength(200, ErrorMessage = "آدرس نمی‌تواند بیشتر از 200 کاراکتر باشد.")]
        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Patient(string nationalCode)
        {
            NationalCode = nationalCode;
            RegistrationDate = DateTime.Now;
        }
    }
} 
