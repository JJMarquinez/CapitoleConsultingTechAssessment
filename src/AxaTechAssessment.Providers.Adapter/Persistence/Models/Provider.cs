namespace AxaTechAssessment.Providers.Adapter.Persistence.Models;

public class Provider
{
    public int ProviderId { get; set; }
    public string Name { get; set; }
    public string PostalAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Type { get; set; }
}
