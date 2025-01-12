using FluentValidation;
using MinimalAPIPeliculas.DTO_s;

namespace MinimalAPIPeliculas.Validaciones
{
    public class EditarClaimDTOValidador : AbstractValidator<EditarClaimDTO>
    {
        public EditarClaimDTOValidador()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Utilidades.CampoRequeridoMensaje)
                .MaximumLength(256).WithMessage(Utilidades.MaximumLenghtMensaje)
                .EmailAddress().WithMessage(Utilidades.EmailMensaje);
        }
    }
}
