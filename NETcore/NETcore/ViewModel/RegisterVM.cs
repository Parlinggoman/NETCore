using NETcore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.ViewModel
{
    public class RegisterVM
    {

        // internal string namalengkap;

        // internal Person.Gender gender;

        //  public static int Count { get; internal set; }
       // [Required]
        public string NamaLengkap { get; set; }
        [Required(ErrorMessage = "NIK Harus di Isi")]
       // [StringLength(9, ErrorMessage = "NIK Harus Terdiri Dari 9 Digit ")]
        public string NIK { get; set; }
        [Required(ErrorMessage ="First Name Harus di Isi")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Harus di Isi")]
        public string LastName { get; set; }
        [Phone(ErrorMessage = "Phone Number Name Harus di Isi")]
       // [StringLength(12,ErrorMessage ="PhoneNumber Harus Terdiri Dari 12 Digit")]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }


        //public int Gender
        //{
        //    Male,
        //    Female
        //}
        public int Gender { get; set; }
        public int Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Harus di Isi")]
        // [MinLength(6,ErrorMessage = "Password Minimal 6 Digit")]
        public string Password { internal get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
       // public object Id { get; internal set; }
        public int UniversityId{ get; set; }

    


        //internal static IEnumerable<RegisterVM> ToList()
        //{
        //    throw new NotImplementedException();
        //}
    }

}

