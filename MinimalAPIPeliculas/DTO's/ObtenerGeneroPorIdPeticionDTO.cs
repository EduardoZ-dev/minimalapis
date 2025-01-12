using AutoMapper;
using MinimalAPIPeliculas.Repositorios;

namespace MinimalAPIPeliculas.DTO_s
{
    public class ObtenerGeneroPorIdPeticionDTO
    {
        public IRepositorioGeneros Repositorio { get; set; }
        public int id { get; set; }
        public IMapper Mapper { get; set; }
    }
}
