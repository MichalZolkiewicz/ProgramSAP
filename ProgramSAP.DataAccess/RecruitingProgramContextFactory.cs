using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProgramSAP.DataAccess;

public class RecruitingProgramContextFactory : IDesignTimeDbContextFactory<RecruitingProgramContext>
{
    public RecruitingProgramContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecruitingProgramContext>();
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-AJM90S2R;Initial Catalog=RecruitingProgram;Integrated Security=True;Encrypt=False");
        return new RecruitingProgramContext(optionsBuilder.Options);
    }
}
