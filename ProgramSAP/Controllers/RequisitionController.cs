using Microsoft.AspNetCore.Mvc;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.Controllers;

[ApiController]
[Route("[controller]")]
public class RequisitionController : ControllerBase
{
    private readonly IRepository<Requisition> requisitionRepository;

    public RequisitionController(IRepository<Requisition> requisitionRepository)
    {
        this.requisitionRepository = requisitionRepository;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<Requisition> GetAllRequisitions() => this.requisitionRepository.GetAll();
}
