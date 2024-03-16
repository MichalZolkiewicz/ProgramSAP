using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Commands;

public class DeleteCandidateCommand : CommandBase<Candidate, Candidate>
{
    public int Id { get; set; }
    public override async Task<Candidate> Execute(RecruitingProgramContext context)
    {
        var candidate = await context.Candidates.FirstOrDefaultAsync(x => x.Id == this.Id);
        context.Candidates.Remove(candidate);
        context.SaveChanges();
        return this.Parameter;
    }
}
