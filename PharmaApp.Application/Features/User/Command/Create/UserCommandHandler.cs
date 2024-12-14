using AutoMapper;
using Azure;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sentry;
using System.Threading;
using PharmaApp.Application.Common.Enum;
using PharmaApp.Application.Common.Utility;
using PharmaApp.Application.Repositorie;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.Enum;
using PharmaApp.Domain.model;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.Create;

public sealed class UserCommandHandler : IRequestHandler<UserCommand, UserCommandResponse>
{
    private readonly IUserRepository _iUserRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserCommandHandler> _logger;
    private readonly IMediator _mediator;
    private readonly IEmailService _emailService;
    private readonly IStorageService _storageService;

    public UserCommandHandler(IUserRepository iUserRepository,
        IMapper mapper, ILogger<UserCommandHandler> logger, IMediator mediator,
        IEmailService emailService, IStorageService storageService)
    {

        _iUserRepository = iUserRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
        _emailService = emailService;
        _storageService = storageService;
    }

    public async Task<UserCommandResponse> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start {nameof(Handle)}");


        UserCommandResponse response = new UserCommandResponse();
        int superAdminId = 0;
        int userId = 0;
        try
        {

            var userProfile = new UserProfile
            {
                FirstName = request.UserDetail.FirstName,
                LastName = request.UserDetail.LastName,
                EmailAddress = request.UserDetail.Email,
                PhoneNumber = request.UserDetail.PhoneNumber,
                Password = request.UserDetail.Password,
                CompanyName = request.UserDetail.CompanyName,
                Address = request.UserDetail.Address,
                State = request.UserDetail.State,
                City = request.UserDetail.City,
                PostalCode = request.UserDetail.PostalCode,
                Fax = request.UserDetail.Fax,
                RoleId =  (int)UserRoleEnum.Admin,
                StatusId =(int)StatusEnum.Active,
                IsActive = true

            };
            var result = await _iUserRepository.AddAsync(userProfile);

            if (result != null)
            {
                MailBody userDetails = new MailBody()
                {
                    PatientName = result.FirstName

                };
                await _emailService.SendEmailAsync(result.EmailAddress, "Patient Profile ", null, null, TemplateEnum.PatientCreation.ToString(), userDetails);
            }


            response.IsSuccess = true;

            _logger.LogInformation($"Exit {nameof(Handle)}");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

}