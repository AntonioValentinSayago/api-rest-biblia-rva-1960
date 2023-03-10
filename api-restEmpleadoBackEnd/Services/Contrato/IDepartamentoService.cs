using api_restEmpleadoBackEnd.Models;

namespace api_restEmpleadoBackEnd.Services.Contrato
{
    public interface IDepartamentoService
    {
        Task<List<Departament>> GetList();
    }
}
