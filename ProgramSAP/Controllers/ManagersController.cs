using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Manager.GetAll;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagersController : ControllerBase
{
    private readonly IMediator mediator;

    public ManagersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllManagers([FromQuery] GetManagersRequest request)
    {
        var response = await mediator.Send(request);
        return this.Ok(response);
    }
}
