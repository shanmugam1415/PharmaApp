using PharmaApp.Domain.Entities;

namespace PharmaApp.Application.Features.Query.GetRegions;

public sealed record GetRegionsResponse
{
    public List<MasterLookUp> Regions { get; set; }
}



