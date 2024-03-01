using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PricingService.Api.Commands;

namespace PricingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _bus;

        public PricingController(IMediator bus)
        {
            _bus = bus;   
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CalculatePriceCommand cmd)
        {
            var result = await _bus.Send(cmd);
            return new JsonResult(result);
        }
    }
}
