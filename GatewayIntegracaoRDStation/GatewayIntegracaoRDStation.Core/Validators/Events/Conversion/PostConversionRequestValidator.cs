using FluentValidation;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;

namespace GatewayIntegracaoRDStation.Core.Validators.Events.Conversion
{
    public class PostConversionRequestValidator : AbstractValidator<PostConversionRequest>
    {
        public PostConversionRequestValidator()
        {
            RuleFor(x => x.EventType)
                .NotNull().NotEmpty();

            RuleFor(x => x.EventFamily)
                .NotNull().NotEmpty();

            RuleFor(x => x.Payload)
                .SetValidator(new PayloadConversionRequestValidator());
        }
    }
}
