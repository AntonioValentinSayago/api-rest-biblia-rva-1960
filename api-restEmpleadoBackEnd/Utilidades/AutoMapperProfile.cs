using AutoMapper;
using api_restEmpleadoBackEnd.DTOs;
using api_restEmpleadoBackEnd.Models;
using System.Globalization;

namespace api_restEmpleadoBackEnd.Utilidades
{
    public class AutoMapperProfile:Profile
    {
      public AutoMapperProfile()
        {
            #region Departamento
            CreateMap<Departament, DepartamentoDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                            destino.NombreDepartamento, opt =>
                            opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre)
                ).ForMember(destino =>
                            destino.FechaContrato, opt =>
                            opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                 destino.IdDepartamentoNavigation, opt => opt.Ignore()
               ).ForMember(destino =>
                 destino.FechaContrato, opt => opt.MapFrom(origen => DateTime.ParseExact
                 (origen.FechaContrato, "dd/MM/yy", CultureInfo.InvariantCulture))
                 );
            #endregion
        }
    }
}
