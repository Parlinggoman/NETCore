using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Model
{
    [Table("tb-m-University")]
    public class University
    {
        public int UniversityId { get; set; }

        [Required]
        public string Name { get; set; }

        // one to many with education 
        public virtual ICollection<Education> Educations { get; set; }


    }
}
