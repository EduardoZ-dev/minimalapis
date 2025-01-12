using FluentValidation;
using MinimalAPIPeliculas.DTO_s;

namespace MinimalAPIPeliculas.Validaciones
{
    public class CrearPeliculaDTOValidador : AbstractValidator<CrearPeliculaDTO>
    {
        public CrearPeliculaDTOValidador()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage(Utilidades.CampoRequeridoMensaje)
                .MaximumLength(150).WithMessage(Utilidades.MaximumLenghtMensaje);
        }
    }
}
