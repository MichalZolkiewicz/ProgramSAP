using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.ApplicationServices.API.Handlers;

public class GetCandidatesHandler : IRequestHandler<GetCandidatesRequest, GetCandidatesResponse>
{
    private readonly IRepository<Candidate> candidateRepository;
    private readonly IMapper mapper;

    public GetCandidatesHandler(IRepository<Candidate> candidateRepository, IMapper mapper)
    {
        this.candidateRepository = candidateRepository;
        this.mapper = mapper;
    }
    public Task<GetCandidatesResponse> Handle(GetCandidatesRequest request, CancellationToken cancellationToken)
    {
        var candidates = candidateRepository.GetAll();
        var mappedCandidates = mapper.Map<List<Domain.Models.Candidate>>(candidates);

        var response = new GetCandidatesResponse()
        {
            Data = mappedCandidates
        };
        return Task.FromResult(response);
    }
}
