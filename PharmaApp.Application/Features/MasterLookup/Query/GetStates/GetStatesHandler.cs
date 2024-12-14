using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.Query.GetStates;

public sealed class GetStatesHandler : IRequestHandler<GetStatesQuery, GetStatesResponse>
{
    private readonly IMasterLookUpRepository _masterLookUpRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetStatesHandler> _logger;
    private readonly IMediator _mediator;
    public GetStatesHandler(IMasterLookUpRepository masterLookUpRepository,
        IMapper mapper, ILogger<GetStatesHandler> logger, IMediator mediator)
    {
        _masterLookUpRepository = masterLookUpRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetStatesResponse> Handle(GetStatesQuery request, CancellationToken cancellationToken)
    {
        
        try
        {
            var states = await _masterLookUpRepository.GetStatesAsync();
            GetStatesResponse response= new GetStatesResponse { States = states};
            
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}