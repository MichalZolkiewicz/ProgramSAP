using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Recruiter.GetAll;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class RecruitersController : ControllerBase
{
    private readonly IMediator mediator;

    public RecruitersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllRecruiters([FromQuery] GetRecruitersRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }
}
