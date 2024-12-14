using MediatR;
using PharmaApp.Application.Features.Query.GetLocations;

namespace PharmaApp.Application.Features.Query.GetLocations
{
    public class GetLocationsQuery : IRequest<GetLocationsResponse>
    {
    }
}