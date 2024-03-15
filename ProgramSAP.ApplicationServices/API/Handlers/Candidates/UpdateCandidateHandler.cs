using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain.Candidate;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Update;
using ProgramSAP.DataAccess.CQRS;
using ProgramSAP.DataAccess.CQRS.Commands;

namespace ProgramSAP.ApplicationServices.API.Handlers.Candidates;

public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateRequest, UpdateCandidateResponse>
{
    private readonly IMapper mapper;
    private readonly ICommandExecutor commandExecutor;

    public UpdateCandidateHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.commandExecutor = commandExecutor;
    }

    public async Task<UpdateCandidateResponse> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
    {
        var candidate = this.mapper.Map<DataAccess.Entities.Candidate>(request);
        var command = new UpdateCandidateCommand() { Parameter =  candidate };
        var updatedCandidate = await commandExecutor.Execute(command);
        return new UpdateCandidateResponse
        {
            Data = this.mapper.Map<Candidate>(updatedCandidate)
        };
    }
}
