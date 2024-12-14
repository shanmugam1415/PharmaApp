using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.Query.GetLocations;

public sealed class GetLocationsHandler : IRequestHandler<GetLocationsQuery, GetLocationsResponse>
{
    private readonly IMasterLookUpRepository _masterLookUpRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetLocationsHandler> _logger;
    private readonly IMediator _mediator;
    public GetLocationsHandler(IMasterLookUpRepository masterLookUpRepository,
        IMapper mapper, ILogger<GetLocationsHandler> logger, IMediator mediator)
    {
        _masterLookUpRepository = masterLookUpRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetLocationsResponse> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        
        try
        {
            var locations = await _masterLookUpRepository.GetLocationsAsync();
            GetLocationsResponse response= new GetLocationsResponse { Locations = locations};
            
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}