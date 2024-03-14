using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly IMediator mediator;

    public CandidatesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllCandidates([FromQuery] GetCandidatesRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddCandidate([FromBody] AddCandidateRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }
}
