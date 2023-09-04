using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class EmailDTO
    {
        public int IdEmail { get; set; }

        public string? SpecialId { get; set; }

        public string? EmailType { get; set; }

        public string? DateLog { get; set; }
        public virtual ICollection<DetailEmailDTO>? DetailEmails { get; set; }

    }
}
