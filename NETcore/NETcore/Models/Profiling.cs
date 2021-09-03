using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETcore.Model
{
    [Table("tb-tr-Profiling")]
    public class Profiling
    {
        //[Key]

        //public string NIK { get; set; }

        //[JsonIgnore]
        //// one to one with Account entities
        //public virtual Account Account { get; set; }

        //// many to one with education
        //public int EducationId { get; set; }
        //[JsonIgnore]
        //public virtual Education Education { get; set; }
        [Key]
       // [StringLength(9, ErrorMessage = "NIK Harus Terdiri Dari 9 Digit ")]
        public string NIK { get; set; }
        [Required]
        public int EducationId { get; set; }
        [JsonIgnore]
        public virtual Education Educations { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
