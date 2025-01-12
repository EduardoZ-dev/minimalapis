using FluentValidation;
using MinimalAPIPeliculas.DTO_s;

namespace MinimalAPIPeliculas.Validaciones
{
    public class CredencialesUsuarioDTOValidador : AbstractValidator<CredencialesUsuarioDTO>
    {
        public CredencialesUsuarioDTOValidador()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Utilidades.CampoRequeridoMensaje)
                .MaximumLength(256).WithMessage(Utilidades.MaximumLenghtMensaje)
                .EmailAddress().WithMessage(Utilidades.EmailMensaje);


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(Utilidades.CampoRequeridoMensaje);

        }
    }
}
