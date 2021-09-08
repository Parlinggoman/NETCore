using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace NETcore.Models
{
    [Table("tb-m-Account")]
    public class Account
    {
        [Key]
        [ForeignKey("Person")]
        [Required]
        //[StringLength(9,ErrorMessage ="NIK Harus Terdiri Dari 9 Digit ")]
        public string NIK { get; set; }
        [Required]
       // [MinLength(6,ErrorMessage ="Password Minimal 6 Digit")]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }
       // public int RoleId { get; set; }

        //public virtual Role Roles { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }
}
