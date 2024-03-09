using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.Repositories;
using ProgramSAP.DataAccess.Entities;


namespace ProgramSAP.ApplicationServices.API.Handlers;

public class GetRequisitionsHandler : IRequestHandler<GetRequisitionsRequest, GetRequisitionsResponse>
{
    private readonly IRepository<Requisition> requisitionRepository;

    public GetRequisitionsHandler(IRepository<Requisition> requisitionRepository)
    {
        this.requisitionRepository = requisitionRepository;
    }
    public Task<GetRequisitionsResponse> Handle(GetRequisitionsRequest request, CancellationToken cancellationToken)
    {
        var requisitions = this.requisitionRepository.GetAll();
        var domainRequisitions = requisitions.Select(x => new Domain.Models.Requisition()
        {
            Id = x.Id,
            Title = x.Title
        });

        var response = new GetRequisitionsResponse()
        {
            Data = domainRequisitions.ToList()
        };
        return Task.FromResult(response);
    }
}
