using api_restEmpleadoBackEnd.Models;
using Microsoft.EntityFrameworkCore;

using api_restEmpleadoBackEnd.Services.Contrato;
using api_restEmpleadoBackEnd.Services.Implementacion;

using AutoMapper;
using api_restEmpleadoBackEnd.DTOs;
using api_restEmpleadoBackEnd.Utilidades;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de Conexion
builder.Services.AddDbContext<ApiRestEmpleadoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("New Politica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region PETICIONES API REST
app.MapGet("/departamento/lista", async(
    IDepartamentoService _departamentoServico,
    IMapper _mapper
    ) =>
{
    var listaDepartamento = await _departamentoServico.GetList();
    var listaDepartamentoDTO = _mapper.Map<List<DepartamentoDTO>>(listaDepartamento);

    if (listaDepartamentoDTO.Count() > 0)
        return Results.Ok(listaDepartamentoDTO);
    else
        return Results.NotFound();
});

app.MapGet("/empleado/lista", async (
    IEmpleadoService _empleadoServicio,
    IMapper _mapper
    ) =>
{
    var listaEmpleado = await _empleadoServicio.GetList();
    var listaEmpleadoDTO = _mapper.Map<List<EmpleadoDTO>>(listaEmpleado);

    if (listaEmpleadoDTO.Count() > 0)
        return Results.Ok(listaEmpleadoDTO);
    else
        return Results.NotFound();
});

app.MapPost("/empleado/guarda", async (
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoServico,
    IMapper _mapper
    ) => { 
        var _empleado = _mapper.Map<Empleado>(modelo);
        var _empleadoCreado = await _empleadoServico.Add(_empleado);

        if (_empleadoCreado.IdEmpleado != 0)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_empleadoCreado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });


app.MapPut("/empleado/actualizar/{idEmpleado}", async (
    int idEmpleado,
    EmpleadoDTO modelo,
    IEmpleadoService _empleadoServico,
    IMapper _mapper
    ) => { 
        var _encontrado = await _empleadoServico.Get(idEmpleado);

        if(_encontrado is null)return Results.NotFound();
        var _empleado = _mapper.Map<Empleado>(modelo);

        _encontrado.NombreCompleto = _empleado.NombreCompleto;
        _encontrado.IdDepartamento = _empleado.IdDepartamento;
        _encontrado.Sueldo = _encontrado.Sueldo;
        _encontrado.FechaContrato = _encontrado.FechaContrato;

        var respuesta = await _empleadoServico.Update(_encontrado);

        if(respuesta)
            return Results.Ok(_mapper.Map<EmpleadoDTO>(_encontrado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });
app.MapDelete("/empleado/eliminar/{idEmpleado}", async (
    int idEmpleado,
    IEmpleadoService _empleadoServico
    ) => {
        var _encontrado = await _empleadoServico.Get(idEmpleado);

        if (_encontrado is null) return Results.NotFound();

        var respuesta = await _empleadoServico.Delete(_encontrado);

        if (respuesta)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

#endregion

app.UseCors("New Politica");

app.Run();
