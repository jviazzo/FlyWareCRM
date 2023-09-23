using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class LoginDTO
    {
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }


        [MinLength(6)]
        [MaxLength(20)]
        public string? Password { get; set; }

    }
}
