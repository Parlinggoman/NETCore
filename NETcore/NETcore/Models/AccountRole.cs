
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Models
{
    [Table("tb_tr_accountroles")]
    public class AccountRole
    {
        [ForeignKey("Account")]
        public string NIK { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
