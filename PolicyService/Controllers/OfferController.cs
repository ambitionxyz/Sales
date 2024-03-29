﻿using EasyNetQ;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Api.Commands;
using static System.String;


namespace PolicyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _bus;

        public OfferController(IMediator bus)
        {
            _bus = bus;  
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOfferCommand cmd, [FromHeader] string AgentLogin)
        {
            var result = IsNullOrWhiteSpace(AgentLogin)
           ? await _bus.Send(cmd)
           : await _bus.Send(new CreateOfferByAgentCommand(AgentLogin, cmd));
            return new JsonResult(result);
        }
    }
}
