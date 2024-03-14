using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.CQRS;
using ProgramSAP.DataAccess.CQRS.Queries;

namespace ProgramSAP.ApplicationServices.API.Handlers.Candidates;

public class GetCandidatesHandler : IRequestHandler<GetCandidatesRequest, GetCandidatesResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetCandidatesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }
    public async Task<GetCandidatesResponse> Handle(GetCandidatesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCandidatesQuery();
        var candidates = await queryExecutor.Execute(query);
        var mappedCandidates = mapper.Map<List<Domain.Models.Candidate>>(candidates);

        var response = new GetCandidatesResponse()
        {
            Data = mappedCandidates
        };
        return response;
    }
}
