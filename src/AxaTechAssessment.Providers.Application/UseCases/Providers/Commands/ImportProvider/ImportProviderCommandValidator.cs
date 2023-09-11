using FluentValidation;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Commands.ImportProvider;

public class ImportProviderCommandValidator : AbstractValidator<ImportProviderCommand>
{
    public ImportProviderCommandValidator()
    {
        RuleForEach(command => command.Providers).ChildRules(provider =>
        { 
            provider.RuleFor(p => p.provider_id).GreaterThan(0);
            provider.RuleFor(p => p.name).NotEmpty();
            provider.RuleFor(p => p.postal_address).NotEmpty();
            provider.RuleFor(p => p.created_at).GreaterThanOrEqualTo(DateTime.Today);
            provider.RuleFor(p => p.type).NotEmpty();
        });
    }
}
