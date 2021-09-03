using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETcore.Model
{
    [Table("tb-m-University")]
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        [Required]
        public string Name { get; set; }


        // one to many with education 
        [JsonIgnore]
        public virtual ICollection<Education> Education { get; set; }
       // public object Id { get; internal set; }
    }
}
