using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NETcore.Model
{
    [Table("tb-tr-Education")]
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string GPA { get; set; }
        public int UniversityId { get; set; }

        [JsonIgnore]
        public virtual University University { get; set; }
        public virtual ICollection<Profiling> Profilings { get; set; }

    }
}
