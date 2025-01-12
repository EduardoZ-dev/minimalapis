using FluentValidation;
using MinimalAPIPeliculas.DTO_s;

namespace MinimalAPIPeliculas.Validaciones
{
    public class CrearComentarioDTOValidador : AbstractValidator<CrearComentarioDTO>
    {
        public CrearComentarioDTOValidador()
        {
            RuleFor(x => x.Cuerpo).NotEmpty().WithMessage(Utilidades.CampoRequeridoMensaje);
        }
    }
}
