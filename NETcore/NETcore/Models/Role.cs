//using NETcore.Model;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NETcore.Models
{
    [Table("tb_m_Roles")]
    public class Role
    {
       
        public int RoleId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountRole>AccountRoles  { get; set; }
        
    }
}
