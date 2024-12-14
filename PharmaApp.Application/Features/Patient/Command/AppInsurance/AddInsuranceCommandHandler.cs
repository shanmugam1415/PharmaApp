using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Common.Enum;
using PharmaApp.Application.Common.Utility;
using PharmaApp.Application.Repositorie;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Entities;
using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.Enum;
using PharmaApp.Domain.model;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.AddInsurance;

public sealed class AddInsuranceCommandHandler : IRequestHandler<AddInsuranceCommand,bool>
{
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AddInsuranceCommandHandler> _logger;
    private readonly IMediator _mediator;

    public AddInsuranceCommandHandler(IInsuranceRepository insuranceRepository, IPatientRepository patientRepository,
        IMapper mapper, ILogger<AddInsuranceCommandHandler> logger,
        IMediator mediator)
    {

        _insuranceRepository = insuranceRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<bool> Handle(AddInsuranceCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start {nameof(Handle)}");
        bool response = false;
        try
        {
            var patient= await _patientRepository.GetByIdAsync(request.PatientId);
            if (patient == null)
            {
                throw new Exception("Inavlid Patient");
            }
            var insurance = new Insurance
            {
                PatientId = request.PatientId,
                PolicyNumber = request.PolicyNumber,
                PolicyValidity = request.PolicyValidity,
                CompanyName = request.CompanyName

            };
            var result = await _insuranceRepository.AddAsync(insurance);

            response= true;

            _logger.LogInformation($"Exit {nameof(Handle)}");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

}