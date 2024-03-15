using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Queries;

public class GetCandidateQuery : QueryBase<Candidate>
{
    public int Id { get; set; }
    public override async Task<Candidate> Execute(RecruitingProgramContext context)
    {
        var candidate = await context.Candidates.FirstOrDefaultAsync(x => x.Id == this.Id);
        return candidate;
    }
}
