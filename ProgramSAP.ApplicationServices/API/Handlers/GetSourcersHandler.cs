using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.ApplicationServices.API.Handlers;

public class GetSourcersHandler : IRequestHandler<GetSourcersRequest, GetSourcersResponse>
{
    private readonly IRepository<Sourcer> sourcerRepository;

    public GetSourcersHandler(IRepository<Sourcer> sourcerRepository)
    {
        this.sourcerRepository = sourcerRepository;
    }
    public async Task<GetSourcersResponse> Handle(GetSourcersRequest request, CancellationToken cancellationToken)
    {
        var sourcers = await sourcerRepository.GetAll();
        var domainSourcers = sourcers.Select(x => new Domain.Models.Sourcer
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
        });

        var response = new GetSourcersResponse
        {
            Data = domainSourcers.ToList()
        };

        return response;
    }
}
