using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class Email
{
    public int IdEmail { get; set; }

    public string? SpecialId { get; set; }

    public string? EmailType { get; set; }

    public DateTime? DateLog { get; set; }

    public virtual ICollection<DetailEmail> DetailEmails { get; set; } = new List<DetailEmail>();
}
