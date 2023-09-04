using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Name { get; set; }

    public int? IdCategory { get; set; }

    public string? Email { get; set; }

    public string? Company { get; set; }

    public string? Language { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateLog { get; set; }

    public virtual ICollection<DetailEmail> DetailEmails { get; set; } = new List<DetailEmail>();

    public virtual Category? IdCategoryNavigation { get; set; }
}
