using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace NETcore.Models
{
    [Table("tb-m-Persons")]

    public class Person
    {
        [Key]
       // [StringLength(9,ErrorMessage = "NIK Harus Terdiri Dari 9 Digit ")]
        public string NIK { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public int Salary { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public enum Gender
        {
            Male,
            Female
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender GenderName { get; set; }

        // one to one with account
        [JsonIgnore]
        public virtual Account Account { get; set; }
       
    }
}
