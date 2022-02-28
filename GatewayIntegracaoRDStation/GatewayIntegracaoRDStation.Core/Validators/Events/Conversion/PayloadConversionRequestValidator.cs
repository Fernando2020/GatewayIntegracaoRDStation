using FluentValidation;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;

namespace GatewayIntegracaoRDStation.Core.Validators.Events.Conversion
{
    public class PayloadConversionRequestValidator : AbstractValidator<PayloadConversionRequest>
    {
        public PayloadConversionRequestValidator()
        {
            RuleFor(x => x.ConversionIdentifier)
                .NotNull().NotEmpty();

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleForEach(x => x.LegalBases)
                .SetValidator(new LegalBasesRequestValidator());
        }
    }
}
