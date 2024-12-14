using PharmaApp.Domain.Entities;

namespace PharmaApp.Application.Features.Query.GetStates;

public sealed record GetStatesResponse
{
    public List<MasterLookUp> States { get; set; }
}



