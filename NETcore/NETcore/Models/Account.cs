using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETcore.Model
{
    [Table("tb-m-Account")]
    public class Account
    {
        [Key]
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
    }
}
