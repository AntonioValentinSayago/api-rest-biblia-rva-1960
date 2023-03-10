namespace api_restEmpleadoBackEnd.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string? NombreCompleto { get; set; }
        public int? IdDepartamento { get; set; }
        public String? NombreDepartamento { get; set; }
        public int? Sueldo { get; set; }
        public String? FechaContrato { get; set; }
    }
}
