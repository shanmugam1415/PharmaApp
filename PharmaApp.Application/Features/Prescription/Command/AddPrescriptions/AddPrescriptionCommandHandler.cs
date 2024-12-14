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

namespace PharmaApp.Application.Features.Command.AddPrescription;

public sealed class AddPrescriptionCommandHandler : IRequestHandler<AddPrescriptionCommand,bool>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionDetailsRepository _prescriptionDetailsRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AddPrescriptionCommandHandler> _logger;
    private readonly IMediator _mediator;

    public AddPrescriptionCommandHandler(IPrescriptionRepository prescriptionRepository, IPrescriptionDetailsRepository prescriptionDetailsRepository , IPatientRepository patientRepository,
        IMapper mapper, ILogger<AddPrescriptionCommandHandler> logger,
        IMediator mediator)
    {
        _prescriptionDetailsRepository = prescriptionDetailsRepository;
        _prescriptionRepository= prescriptionRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<bool> Handle(AddPrescriptionCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start {nameof(Handle)}");
        bool response = false;
        try
        {
            var patient = await _patientRepository.GetByIdAsync(request.PatientId);
            if (patient == null)
            {
                throw new Exception("Inavlid Patient");
            }
            var prescription = new Prescription
            {
                PatientId = request.PatientId,
                DoctorName = request.DoctorName,
                Date = request.Date,
                IsDispensed = false

            };
            var result = await _prescriptionRepository.AddAsync(prescription);
            if (result != null && request.PrescriptionDetails != null)
            {
                {
                    List<PrescriptionDetails> prescriptionDetails = new List<PrescriptionDetails>();
                    foreach (var details in request.PrescriptionDetails)
                    {
                        PrescriptionDetails detail = new PrescriptionDetails()
                        {
                            DaysSupply = details.DaysSupply,
                            Dosage = details.Dosage,
                            Quantity = details.Quantity,
                            PrescriptionId = result.Id,
                            MedicationCode = details.MedicationCode,
                            MedicationName = details.MedicationName

                        };
                        prescriptionDetails.Add(detail);
                    }
                    await _prescriptionDetailsRepository.AddPrescriptionDetails(prescriptionDetails);

                }

                response = true;

                _logger.LogInformation($"Exit {nameof(Handle)}");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

}