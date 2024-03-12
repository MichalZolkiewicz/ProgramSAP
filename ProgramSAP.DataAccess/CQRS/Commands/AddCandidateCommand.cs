using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Commands;

public class AddCandidateCommand : CommandBase<Candidate, Candidate>
{
    public override async Task<Candidate> Execute(RecruitingProgramContext context)
    {
        await context.Candidates.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
