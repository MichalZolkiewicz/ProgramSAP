using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Delete;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.GetAll;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.GetById;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Update;

namespace ProgramSAP.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class CandidatesController : ApiControllerBase
{
    private readonly IMediator mediator;

    public CandidatesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllCandidates([FromQuery] GetCandidatesRequest request)
    {
        return this.HandleRequest<GetCandidatesRequest, GetCandidatesResponse>(request);
    }

    [HttpGet]
    [Route("{candidateId}")]
    public Task<IActionResult> GetCandidateById([FromRoute] int candidateId)
    {
        var request = new GetCandidateByIdRequest
        {
            CandidateId = candidateId
        };
        return this.HandleRequest<GetCandidateByIdRequest, GetCandidateByIdResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddCandidate([FromBody] AddCandidateRequest request)
    {
        return this.HandleRequest<AddCandidateRequest, AddCandidateRespone>(request);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> UpdateCandidate([FromBody] UpdateCandidateRequest request)
    {
        return this.HandleRequest<UpdateCandidateRequest, UpdateCandidateResponse>(request);
    }

    [HttpDelete]
    [Route("{candidateId}")]
    public Task<IActionResult> DeleteCandidate([FromRoute] int candidateId)
    {
        var request = new DeleteCandidateRequest
        {
            CandidateId = candidateId
        };
        return this.HandleRequest<DeleteCandidateRequest, DeleteCandidateResponse>(request);
    }
}
