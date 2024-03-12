using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.CQRS.Queries;

public class GetCandidatesQuery : QueryBase<List<Candidate>>
{
    public override Task<List<Candidate>> Execute(RecruitingProgramContext context)
    {
        return context.Candidates.ToListAsync();
    }
}
