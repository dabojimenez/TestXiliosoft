using System;
using System.Collections.Generic;

namespace TestXiliosoft.Models;

public partial class Asignacione
{
    public int Id { get; set; }

    public string? Serie { get; set; }

    public string? Cedula { get; set; }

    public virtual Empleado? CedulaNavigation { get; set; }

    public virtual Maquinarium? SerieNavigation { get; set; }
}
