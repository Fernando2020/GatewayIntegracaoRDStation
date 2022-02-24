using FluentValidation;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;

namespace GatewayIntegracaoRDStation.Core.Validators.Events.CartAbandonment
{
    public class PostCartAbandonmentRequestValidator : AbstractValidator<PostCartAbandonmentRequest>
    {
        public PostCartAbandonmentRequestValidator()
        {
            RuleFor(x => x.EventType)
                .NotNull().NotEmpty();

            RuleFor(x => x.EventFamily)
                .NotNull().NotEmpty();

            RuleFor(x => x.Payload)
                .SetValidator(new PayloadCartAbandonmentRequestValidator());
        }
    }
}
