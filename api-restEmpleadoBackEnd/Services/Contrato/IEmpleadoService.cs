using api_restEmpleadoBackEnd.Models;

namespace api_restEmpleadoBackEnd.Services.Contrato
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> GetList();
        Task<Empleado> Get(int idEmpleado);
        Task<Empleado> Add(Empleado modelo);
        Task<bool> Update(int idEmpleado);
        Task<bool> Delete(int idEmpleado);
    }
}
