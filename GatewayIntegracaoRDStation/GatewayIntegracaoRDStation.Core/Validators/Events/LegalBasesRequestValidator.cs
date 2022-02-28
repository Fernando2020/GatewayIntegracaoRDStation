using FluentValidation;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;

namespace GatewayIntegracaoRDStation.Core.Validators.Events
{
    public class LegalBasesRequestValidator : AbstractValidator<LegalBasesRequest>
    {
        public LegalBasesRequestValidator()
        {
            RuleFor(x => x.Category)
                .NotNull().NotEmpty();

            RuleFor(x => x.Type)
                .NotNull().NotEmpty();

            RuleFor(x => x.Status)
                .NotNull().NotEmpty();
        }
    }
}
