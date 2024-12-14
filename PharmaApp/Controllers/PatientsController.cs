using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using PharmaApp.Application.Features.Command.Create;
using PharmaApp.Application.Features.Query.GetPatientQuery;
using PharmaApp.Application.Features.Command.AddInsurance;
using PharmaApp.Application.Features.User.Command.Update;

namespace PharmaApp.API.Controllers
{

    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientUpdateCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPatient/{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var query = new GetPatientQuery { Id = id };
            var patient = await _mediator.Send(query);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost("assign-insurance")]
        public async Task<IActionResult> AssignInsurance([FromBody] AddInsuranceCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
