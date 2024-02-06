using System;
using System.Collections.Generic;

namespace TestXiliosoft.Models;

public partial class Maquinarium
{
    public string Serie { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
}
