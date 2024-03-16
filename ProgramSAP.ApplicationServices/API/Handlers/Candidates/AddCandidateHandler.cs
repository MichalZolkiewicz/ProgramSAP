using AutoMapper;
using MediatR;
using ProgramSAP.ApplicationServices.API.Domain.Candidate;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;
using ProgramSAP.DataAccess.CQRS;
using ProgramSAP.DataAccess.CQRS.Commands;

namespace ProgramSAP.ApplicationServices.API.Handlers.Candidates;

public class AddCandidateHandler : IRequestHandler<AddCandidateRequest, AddCandidateRespone>
{
    private readonly IMapper mapper;
    private readonly ICommandExecutor commandExecutor;

    public AddCandidateHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        this.mapper = mapper;
        this.commandExecutor = commandExecutor;
    }
    public async Task<AddCandidateRespone> Handle(AddCandidateRequest request, CancellationToken cancellationToken)
    {
        var candidate = this.mapper.Map<DataAccess.Entities.Candidate>(request);
        var command = new AddCandidateCommand() { Parameter = candidate };
        var candidateFromDb = await this.commandExecutor.Execute(command);
        return new AddCandidateRespone()
        {
            Data = this.mapper.Map<Candidate>(candidateFromDb)
        };
    }
}
