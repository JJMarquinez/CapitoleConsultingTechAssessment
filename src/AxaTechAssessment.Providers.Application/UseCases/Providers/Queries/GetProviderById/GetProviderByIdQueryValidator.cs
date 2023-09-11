using FluentValidation;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Queries.GetProviderById;

public class GetProviderByIdQueryValidator : AbstractValidator<GetProviderByIdQuery>
{
    public GetProviderByIdQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0); // Specific bussiness rule
    }
}
