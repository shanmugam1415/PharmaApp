using PharmaApp.Domain.Entities;

namespace PharmaApp.Application.Features.Query.GetLocations;

public sealed record GetLocationsResponse
{
    public List<MasterLookUp> Locations { get; set; }
}



