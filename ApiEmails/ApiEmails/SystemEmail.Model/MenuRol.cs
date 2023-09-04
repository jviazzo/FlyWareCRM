﻿using System;
using System.Collections.Generic;

namespace SystemEmail.Model;

public partial class MenuRol
{
    public int IdMenulRol { get; set; }

    public int? IdMenu { get; set; }

    public int? IdRol { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
