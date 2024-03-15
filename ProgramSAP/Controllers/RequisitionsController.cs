using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Requisition.GetAll;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class RequisitionsController : ControllerBase
{
    private readonly IMediator mediator;

    public RequisitionsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllRequisition([FromQuery] GetRequisitionsRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }
}
