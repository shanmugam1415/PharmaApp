using Microsoft.AspNetCore.Mvc;
using PharmaApp.Application.Features.Login.command;

namespace PharmaApp.API.Controllers
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HeathcheckController : Controller
    {
           [HttpGet]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
