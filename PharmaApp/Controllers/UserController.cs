using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using PharmaApp.Application.Features.Command.Create;
using PharmaApp.Application.Features.Login.command;
using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.model;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.API.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        

        [HttpPost("registration")]
        public async Task<IActionResult> SaveUser([FromForm]UserCommand request, CancellationToken cancellationToken)
        {
          
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _mediator.Send(new LoginCommand
                {
                    Username = request.Username,
                    Password = request.Password
                });

                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("generate-verify-2fa")]
        public async Task<IActionResult> GenerateAuthCode([FromBody] AuthCodeRequest request)
        {
            var isEmailSent = await _mediator.Send(new GenerateAuthCodeCommand
            {
                UserId = request.UserId,
                EmailId = request.EmailId,
                Password = request.Password,
            });

            return Ok(new { IsEmailSent = isEmailSent });
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyAuthCode([FromBody] VerifyAuthCodeRequest request)
        {
            var isValid = await _mediator.Send(new VerifyAuthCodeCommand(request.UserId, request.Email, request.Code));

            if (isValid)
            {
                return Ok(new { IsValid=true,Message = "Two Factor authentication verified successfully." });
            }

            return BadRequest(new { Message = "Invalid or expired token." });
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var isSuccess = await _mediator.Send(new ForgotPasswordCommand
            {
                Email = request.Email
            });

            return Ok(new { IsSuccess = isSuccess });
        }


       
    }
}
