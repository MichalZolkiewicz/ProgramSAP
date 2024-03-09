using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.ApplicationServices.API.Handlers;

public class GetCandidatesHandler : IRequestHandler<GetCandidatesRequest, GetCandidatesResponse>
{
    private readonly IRepository<Candidate> candidateRepository;

    public GetCandidatesHandler(IRepository<Candidate> candidateRepository)
    {
        this.candidateRepository = candidateRepository;
    }
    public Task<GetCandidatesResponse> Handle(GetCandidatesRequest request, CancellationToken cancellationToken)
    {
        var candidates = candidateRepository.GetAll();
        var domainCandidates = candidates.Select(x => new Domain.Models.Candidate
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
        });

        var response = new GetCandidatesResponse()
        {
            Data = domainCandidates.ToList()
        };
        return Task.FromResult(response);
    }
}
