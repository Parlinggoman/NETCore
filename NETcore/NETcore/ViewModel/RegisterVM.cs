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
        [Required(ErrorMessage ="BirthDate Harus diisi")]
        public DateTime BirthDate { get; set; }


        //public int Gender
        //{
        //    Male,
        //    Female
        //}
        [Required, Range(0, 1, ErrorMessage = "Gender harus diantara 0 atau 1")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Salary Depan tidak boleh kosong")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Email tidak boleh kosong"),
       EmailAddress(ErrorMessage = "Alamat Email tidak valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong"),
         MinLength(8, ErrorMessage = "Password Minimal 8 Karakter"),
         RegularExpression("^(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z])(?=\\D*\\d)[^:&.~\\s]{5,20}$", ErrorMessage = "Password harus mengadung huruf besar,huruf kecil dan angka ")]
        public string Password { internal get; set; }
        [Required(ErrorMessage = "Degree tidak boleh kosong")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "GPA tidak boleh kosong")]
        public string GPA { get; set; }
        [Required(ErrorMessage = "UniversityId tidak boleh kosong")]
        public int UniversityId{ get; set; }

        [Required(ErrorMessage = "RoleId tidak boleh kosong")]
        public int RoleId { get; set; }



    }

}

