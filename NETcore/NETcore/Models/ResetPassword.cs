using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Model
{
    [Table("tb_m_reset_passwords")]
    public class ResetPassword
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
        public string NIK { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
