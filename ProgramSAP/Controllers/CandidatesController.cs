using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.GetAll;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.GetById;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Update;

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

    [HttpGet]
    [Route("{candidateId}")]
    public async Task<IActionResult> GetCandidateById([FromRoute] int candidateId)
    {
        var request = new GetCandidateByIdRequest
        {
            CandidateId = candidateId
        };
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

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> UpdateCandidate([FromBody] UpdateCandidateRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }
}
