using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.Query.GetRegions;

public sealed class GetRegionsHandler : IRequestHandler<GetRegionsQuery, GetRegionsResponse>
{
    private readonly IMasterLookUpRepository _masterLookUpRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetRegionsHandler> _logger;
    private readonly IMediator _mediator;
    public GetRegionsHandler(IMasterLookUpRepository masterLookUpRepository,
        IMapper mapper, ILogger<GetRegionsHandler> logger, IMediator mediator)
    {
        _masterLookUpRepository = masterLookUpRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetRegionsResponse> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        
        try
        {
            var regions = await _masterLookUpRepository.GetRegionsAsync();
            GetRegionsResponse response= new GetRegionsResponse { Regions = regions };
            
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}