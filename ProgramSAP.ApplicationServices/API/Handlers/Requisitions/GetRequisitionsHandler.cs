using MediatR;
using ProgramSAP.DataAccess.Repositories;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.ApplicationServices.API.Domain.Requisition.GetAll;

namespace ProgramSAP.ApplicationServices.API.Handlers.Requisitions;

public class GetRequisitionsHandler : IRequestHandler<GetRequisitionsRequest, GetRequisitionsResponse>
{
    private readonly IRepository<Requisition> requisitionRepository;

    public GetRequisitionsHandler(IRepository<Requisition> requisitionRepository)
    {
        this.requisitionRepository = requisitionRepository;
    }
    public async Task<GetRequisitionsResponse> Handle(GetRequisitionsRequest request, CancellationToken cancellationToken)
    {
        var requisitions = await requisitionRepository.GetAll();
        var domainRequisitions = requisitions.Select(x => new Domain.Requisition.Requisition()
        {
            Id = x.Id,
            Title = x.Title
        });

        var response = new GetRequisitionsResponse()
        {
            Data = domainRequisitions.ToList()
        };
        return response;
    }
}
