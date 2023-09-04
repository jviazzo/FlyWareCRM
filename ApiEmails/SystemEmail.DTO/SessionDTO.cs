using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class SessionDTO
    {
        public int IdUser { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? RolDescription { get; set; }

    }
}
