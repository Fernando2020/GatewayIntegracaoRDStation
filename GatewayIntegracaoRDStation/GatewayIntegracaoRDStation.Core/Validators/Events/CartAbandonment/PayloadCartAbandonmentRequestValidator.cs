using FluentValidation;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;

namespace GatewayIntegracaoRDStation.Core.Validators.Events.CartAbandonment
{
    public class PayloadCartAbandonmentRequestValidator : AbstractValidator<PayloadCartAbandonmentRequest>
    {
        public PayloadCartAbandonmentRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CfCartId)
                .NotNull().NotEmpty();

            RuleFor(x => x.CfCartTotalItems)
                .NotNull().NotEmpty();

            RuleFor(x => x.CfCartStatus)
                .NotNull().NotEmpty();

            RuleForEach(x => x.LegalBases)
                .SetValidator(new LegalBasesRequestValidator());
        }
    }
}
