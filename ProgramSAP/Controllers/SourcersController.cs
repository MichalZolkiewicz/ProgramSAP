using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class SourcersController : ControllerBase
{
    private readonly IMediator mediator;

    public SourcersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllSourcers([FromQuery] GetSourcersRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }
}
