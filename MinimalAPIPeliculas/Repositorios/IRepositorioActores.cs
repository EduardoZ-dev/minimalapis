using MinimalAPIPeliculas.DTO_s;
using MinimalAPIPeliculas.Entidades;

namespace MinimalAPIPeliculas.Repositorios
{
    public interface IRepositorioActores
    {
        Task Actualizar(Actor actor);
        Task Borrar(int id);
        Task<int> Crear(Actor actor);
        Task<bool> Existe(int id);
        Task<List<int>> Existen(List<int> ids);
        Task<List<Actor>> ObtenerTodos(PaginacionDTO paginacionDTO);
        Task<Actor?> ObtenerPorId(int id);
        Task<List<Actor>> ObtenerPorNombre(string nombre);
    }
}