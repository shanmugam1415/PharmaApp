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

namespace PharmaApp.Application.Features.Command.DespensePrescription;

public sealed class DespensePrescriptionCommandHandler : IRequestHandler<DespensePrescriptionCommand, bool>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionDetailsRepository _prescriptionDetailsRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DespensePrescriptionCommandHandler> _logger;
    private readonly IMediator _mediator;

    public DespensePrescriptionCommandHandler(IPrescriptionRepository prescriptionRepository, IPrescriptionDetailsRepository prescriptionDetailsRepository, IPatientRepository patientRepository,
        IMapper mapper, ILogger<DespensePrescriptionCommandHandler> logger,
        IMediator mediator)
    {
        _prescriptionDetailsRepository = prescriptionDetailsRepository;
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<bool> Handle(DespensePrescriptionCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start {nameof(Handle)}");
        bool response = false;
        try
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(request.PrescriptionId);
            if (prescription == null)
            {
                throw new Exception("Inavlid PrescriptionId");
            }
            prescription.IsDispensed = true;
            await _prescriptionRepository.Update(prescription);
            response = true;

            _logger.LogInformation($"Prescription despensed successfully");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

}