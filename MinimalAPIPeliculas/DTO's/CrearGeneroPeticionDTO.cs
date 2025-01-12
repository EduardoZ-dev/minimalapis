using AutoMapper;
using Microsoft.AspNetCore.OutputCaching;
using MinimalAPIPeliculas.Repositorios;

namespace MinimalAPIPeliculas.DTO_s
{
    public class CrearGeneroPeticionDTO
    {
        public int Id { get; set; }
        public IRepositorioGeneros Repositorio { get; set;}
        public IOutputCacheStore OutputCacheStore { get; set; }
        public IMapper Mapper { get; set; }
    }
}
