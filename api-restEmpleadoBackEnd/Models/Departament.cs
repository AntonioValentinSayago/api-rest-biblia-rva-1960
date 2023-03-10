using System;
using System.Collections.Generic;

namespace api_restEmpleadoBackEnd.Models;

public partial class Departament
{
    public int IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
