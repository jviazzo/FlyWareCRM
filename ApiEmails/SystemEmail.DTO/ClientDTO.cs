using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class ClientDTO
    {
        public int IdClient { get; set; }

        public string? Name { get; set; }

        public int? IdCategory { get; set; }

        public string? CategoryDescription { get; set; }

        public string? Email { get; set; }

        public string? Company { get; set; }

        public string? Language { get; set; }

        public int? IsActive { get; set; }


    }
}
