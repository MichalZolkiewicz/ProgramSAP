using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Commands;

public class UpdateCandidateCommand : CommandBase<Candidate, Candidate>
{
    public override async Task<Candidate> Execute(RecruitingProgramContext context)
    {
        var candidate = await context.Candidates.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
        if (candidate != null) 
        {
            candidate.Name = this.Parameter.Name;
            candidate.Surname = this.Parameter.Surname;
            candidate.Email = this.Parameter.Email;
        }
        else
        {
            return default;
        }
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
