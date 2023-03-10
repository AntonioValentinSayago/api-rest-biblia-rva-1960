using System;
using System.Collections.Generic;

namespace api_restEmpleadoBackEnd.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreCompleto { get; set; }

    public int? IdDepartamento { get; set; }

    public int? Sueldo { get; set; }

    public DateTime? FechaContrato { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Departament? IdDepartamentoNavigation { get; set; }
}
