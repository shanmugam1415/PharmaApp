using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Repositories;
using Sentry;

namespace PharmaApp.Application.Features.Query.GetPatientQuery;

public sealed class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GetPatientQueryResponse>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPatientQueryHandler> _logger;
    private readonly IMediator _mediator;
    public GetPatientQueryHandler(IPatientRepository patientRepository,
        IMapper mapper, ILogger<GetPatientQueryHandler> logger, IMediator mediator)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetPatientQueryResponse> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {

        try
        {
            var patient = await _patientRepository.GetPatientByIdAsync(request.Id);
            if (patient != null)
            {

                var response = _mapper.Map<GetPatientQueryResponse>(patient);
                return response;
            }
            else
            {
                throw new Exception("No patient found");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new Exception("An Error Occurred");
        }
    }
}