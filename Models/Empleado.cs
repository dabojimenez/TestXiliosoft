using System;
using System.Collections.Generic;

namespace TestXiliosoft.Models;

public partial class Empleado
{
    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public string Cedula { get; set; } = null!;

    public string? Area { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
}
