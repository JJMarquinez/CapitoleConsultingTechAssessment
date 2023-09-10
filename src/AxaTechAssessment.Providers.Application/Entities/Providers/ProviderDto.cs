using AutoMapper;
using AxaTechAssessment.Providers.Application.Mappings;
using AxaTechAssessment.Providers.Domain.Entities;

namespace AxaTechAssessment.Providers.Application.Entities.Providers;

public class ProviderDto : IMapFrom<Provider>
{
    public int provider_id { get; set; }
    public string name { get; set; }
    public string postal_address { get; set; }
    public DateTime created_at { get; set; }
    public string type { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Provider, ProviderDto>()
            .ForMember(d => d.provider_id, opt => opt.MapFrom(s => s.ProviderId))
            .ForMember(d => d.name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.postal_address, opt => opt.MapFrom(s => s.PostalAddress))
            .ForMember(d => d.created_at, opt => opt.MapFrom(s => s.CreatedAt))
            .ForMember(d => d.type, opt => opt.MapFrom(s => s.Type));
    }
}
