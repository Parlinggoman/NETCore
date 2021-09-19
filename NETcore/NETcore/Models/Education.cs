using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETcore.Models
{
    [Table("tb-tr-Education")]
    public class Education
    {
     
        public Education(string degree, string gPA, int universityId)
        {
            Degree = degree;
            GPA = gPA;
            UniversityId = universityId;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string GPA { get; set; }
        [Required]
        public int UniversityId { get; set; }

          [JsonIgnore]
        public virtual University University { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profiling { get; set; }
        //public int EducationId { get; internal set; }
    }
}
