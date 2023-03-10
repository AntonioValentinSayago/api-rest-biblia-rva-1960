using Microsoft.EntityFrameworkCore;
using api_restEmpleadoBackEnd.Models;
using api_restEmpleadoBackEnd.Services.Contrato;

namespace api_restEmpleadoBackEnd.Services.Implementacion
{
    public class DepartamentoService:IDepartamentoService
    {
        private ApiRestEmpleadoContext _dbContext;
        public DepartamentoService(ApiRestEmpleadoContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<Departament>> GetList()
        {
            try
            {
                List<Departament> lista = new List<Departament>();
                lista = await _dbContext.Departaments.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
