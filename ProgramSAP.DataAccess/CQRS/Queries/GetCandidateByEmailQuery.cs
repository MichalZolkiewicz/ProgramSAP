using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Queries;

public class GetCandidateByEmailQuery : QueryBase<Candidate>
{
    public string Email { get; set; }
    public override Task<Candidate> Execute(RecruitingProgramContext context)
    {
        return context.Candidates.FirstOrDefaultAsync(x => x.Email == this.Email);
    }
}
