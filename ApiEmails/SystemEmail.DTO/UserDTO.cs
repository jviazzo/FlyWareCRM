using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SystemEmail.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [StringLength(100)]
        public string? FullName { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescription { get; set; }


        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }


        [MinLength(6)]
        [MaxLength(20)]
        public string? Password { get; set; }

        public int? IsActive { get; set; }
    }
}
