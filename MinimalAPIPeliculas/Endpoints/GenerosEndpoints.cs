using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;
using MinimalAPIPeliculas.DTO_s;
using MinimalAPIPeliculas.Entidades;
using MinimalAPIPeliculas.Filtros;
using MinimalAPIPeliculas.Repositorios;

namespace MinimalAPIPeliculas.Endpoints
{
    public static class GenerosEndpoints  
    {
        public static RouteGroupBuilder MapGeneros (this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerGeneros)
                .CacheOutput(c => c.Expire(TimeSpan.FromSeconds(60)).Tag("generos-get"));
            group.MapGet("/{id}", ObtenerGeneroPorId);
            group.MapPost("/", CrearGenero).AddEndpointFilter<FiltroValidaciones<CrearGeneroDTO>>()
                .RequireAuthorization("esadmin");

            group.MapPut("/{id}", ActualizarGenero)
                .AddEndpointFilter<FiltroValidaciones<CrearGeneroDTO>>()
                .RequireAuthorization("esadmin")
                .WithOpenApi(opciones =>
                {
                    opciones.Summary = "Actualizar un género";
                    opciones.Description = "Con este endpoint podemos actualizar un genero";
                    opciones.Parameters[0].Description = "El id del género a actualizar";
                    opciones.RequestBody.Description = "El género que se desea actualizar";


                    return opciones;
                });

            group.MapDelete("/{id}", BorrarGenero).RequireAuthorization("esadmin");

            return group;
        }
 
        static async Task<Ok<List<GeneroDTO>>> ObtenerGeneros(IRepositorioGeneros repositorio,
            IMapper mapper, ILoggerFactory loggerFactory)
        {
            var tipo = typeof(GenerosEndpoints);
            var logger = loggerFactory.CreateLogger(tipo.FullName!);

            //logger.LogInformation("Obtener Listado de Generos");
            logger.LogTrace("Este es un mensaje de trace");
            logger.LogDebug("Este es un mensaje de debug");
            logger.LogInformation("Este es un mensaje de informarion");
            logger.LogWarning("Este es un mensaje de warning");
            logger.LogError("Este es un mensaje de error");
            logger.LogCritical("Este es un mensaje de critical");
            
            
            logger.LogCritical("");

            var generos = await repositorio.ObtenerTodos();
            var generosDTO = mapper.Map<List<GeneroDTO>>(generos);
            return TypedResults.Ok(generosDTO);

        }

        static async Task<Results<Ok<GeneroDTO>, NotFound>> ObtenerGeneroPorId
            ([AsParameters] ObtenerGeneroPorIdPeticionDTO modelo)
        {
            var genero = await modelo.Repositorio.ObtenerPorId(modelo.id);

            if (genero is null)
            {
                return TypedResults.NotFound();
            }

            var generoDTO = modelo.Mapper.Map<GeneroDTO>(genero);

            /*var generoDTO = new GeneroDTO
            {
                Id = id,
                Nombre = genero.Nombre,
            };*/

            return TypedResults.Ok(generoDTO);
        }

        static async Task<Results<Created<GeneroDTO>, ValidationProblem>>CrearGenero(CrearGeneroDTO crearGeneroDTO,
            IRepositorioGeneros repositorio,IOutputCacheStore outputCache, IMapper mapper)
        {

            var genero = mapper.Map<Genero>(crearGeneroDTO);
            var id = await repositorio.Crear(genero);
            await outputCache.EvictByTagAsync("generos-get", default);
            var generoDTO = mapper.Map<GeneroDTO>(genero);
            return TypedResults.Created($"/generos/{id}", generoDTO);
        }

        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarGenero(CrearGeneroDTO crearGeneroDTO,
            [AsParameters] CrearGeneroPeticionDTO modelo)

        {


            var existe = await modelo.Repositorio.Existe(modelo.Id);

            if (!existe)
            {
                return TypedResults.NotFound();
            }


            var genero = modelo.Mapper.Map<Genero>(crearGeneroDTO);
            genero.Id = modelo.Id;

            /*var genero = new Genero
            {
                Nombre = crearGeneroDTO.Nombre,
                Id = id,
            };*/

            await modelo.Repositorio.Actualizar(genero);
            await modelo.OutputCacheStore.EvictByTagAsync("generos-get", default);
            return TypedResults.NoContent();


        }

        static async Task<Results<NoContent, NotFound>> BorrarGenero(int id, IRepositorioGeneros repositorio, IOutputCacheStore outputCacheStore)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return TypedResults.NotFound();
            }

            await repositorio.Borrar(id);
            await outputCacheStore.EvictByTagAsync("generos-get", default);
            return TypedResults.NoContent();

        }


    }
}
