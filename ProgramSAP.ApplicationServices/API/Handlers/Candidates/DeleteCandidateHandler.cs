using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain.Candidate;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Delete;
using ProgramSAP.DataAccess.CQRS;
using ProgramSAP.DataAccess.CQRS.Commands;

namespace ProgramSAP.ApplicationServices.API.Handlers.Candidates;

public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateRequest, DeleteCandidateResponse>
{
    private readonly IMapper mapper;
    private readonly ICommandExecutor commandExecutor;

    public DeleteCandidateHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.commandExecutor = commandExecutor;
    }
    public async Task<DeleteCandidateResponse> Handle(DeleteCandidateRequest request, CancellationToken cancellationToken)
    {
        var command = new DeleteCandidateCommand()
        {
            Id = request.CandidateId
        };

        var candidate = await commandExecutor.Execute(command);
        var mappedCandidate = mapper.Map<Candidate>(candidate);

        var response = new DeleteCandidateResponse()
        {
            Data = mappedCandidate
        };
        return response;
    }
}
