using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Name { get; set; }

    public DateTime? DateLog { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
