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

namespace PharmaApp.Application.Features.Command.Create;

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand,bool>
{
    private readonly IUserRepository _iUserRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreatePatientCommandHandler> _logger;
    private readonly IMediator _mediator;
    private readonly IEmailService _emailService;

    public CreatePatientCommandHandler(IUserRepository iUserRepository, IPatientRepository patientRepository,
        IMapper mapper, ILogger<CreatePatientCommandHandler> logger,
        IMediator mediator,
        IEmailService emailService)
    {

        _iUserRepository = iUserRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
        _emailService = emailService;
    }

    public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start {nameof(Handle)}");
        bool response = false;
        try
        {
            
            var patientDetails = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                State = request.State,
                City = request.City

            };
            var result = await _patientRepository.AddAsync(patientDetails);

            if (result != null)
            {
                MailBody userDetails = new MailBody()
                {
                    PatientName = result.FirstName
                };
                await _emailService.SendEmailAsync(result.EmailAddress, "Patient Creation completed", null, null, TemplateEnum.PatientCreation.ToString(), userDetails);
            }


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