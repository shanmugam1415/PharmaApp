using Cqrs.Domain;
using MediatR;
using System;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.User.Command.Update
{
    public class PatientUpdateCommandHandler : IRequestHandler<PatientUpdateCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;
        public PatientUpdateCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool response = false;
                var patientDetails = await _patientRepository.GetByIdAsync(request.PatientId);

                if (patientDetails != null)
                {
                    patientDetails.FirstName = request.PhoneNumber;
                    patientDetails.LastName = request.LastName;
                    patientDetails.Address = request.Address;
                    patientDetails.PhoneNumber = request.PhoneNumber;
                    patientDetails.EmailAddress = request.EmailAddress;
                    patientDetails.State = request.State;
                    patientDetails.City = request.City;
                    await _patientRepository.Update(patientDetails);
                    response= true;
                }
                else
                {
                    throw new ApplicationException("Patient Not Found");
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
