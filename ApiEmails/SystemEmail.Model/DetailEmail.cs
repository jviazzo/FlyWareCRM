using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class DetailEmail
{
    public int IdDetailEmail { get; set; }

    public int? IdEmail { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Email? IdEmailNavigation { get; set; }
}
