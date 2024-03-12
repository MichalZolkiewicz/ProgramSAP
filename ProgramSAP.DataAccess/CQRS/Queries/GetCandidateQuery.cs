using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.DataAccess.CQRS.Queries;

public class GetCandidateQuery : QueryBase<Candidate>
{
    public int Id { get; set; }
    public override async Task<Candidate> Execute(RecruitingProgramContext context)
    {
        var book = await context.Candidates.FirstOrDefaultAsync(x => x.Id == this.Id);
        return book;
    }
}
