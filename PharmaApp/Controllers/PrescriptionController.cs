using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using PharmaApp.Application.Features.Command.Create;
using PharmaApp.Application.Features.Query.GetPatientQuery;
using PharmaApp.Application.Features.Command.AddInsurance;
using PharmaApp.Application.Features.Command.AddPrescription;
using PharmaApp.Application.Features.Command.DespensePrescription;

namespace PharmaApp.API.Controllers
{

    [ApiController]
    [Route("api/prescription")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePrescription([FromBody] AddPrescriptionCommand command)
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

        [HttpPost("dispense")]
        public async Task<IActionResult> DispensePrescription([FromBody] DespensePrescriptionCommand command)
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
