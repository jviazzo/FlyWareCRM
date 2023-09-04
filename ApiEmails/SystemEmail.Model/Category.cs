using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateLog { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
