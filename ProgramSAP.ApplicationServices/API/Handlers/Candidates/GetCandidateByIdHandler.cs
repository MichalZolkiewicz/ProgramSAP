using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain.Candidate;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.GetById;
using ProgramSAP.DataAccess.CQRS;
using ProgramSAP.DataAccess.CQRS.Queries;

namespace ProgramSAP.ApplicationServices.API.Handlers.Candidates;

public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdRequest, GetCandidateByIdResponse>
{
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public GetCandidateByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<GetCandidateByIdResponse> Handle(GetCandidateByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCandidateQuery()
        {
            Id = request.CandidateId
        };
        var candidate = await queryExecutor.Execute(query);
        var mappedCandidate = mapper.Map<Candidate>(candidate);

        var response = new GetCandidateByIdResponse()
        {
            Data = mappedCandidate
        };
        return response;
    }
}
