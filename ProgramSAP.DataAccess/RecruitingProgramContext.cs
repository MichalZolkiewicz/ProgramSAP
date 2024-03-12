using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess;

public class RecruitingProgramContext : DbContext
{
    public RecruitingProgramContext(DbContextOptions<RecruitingProgramContext> options)
        :base(options)
    {
    }
    public DbSet<Requisition> Requisitions { get; set; }

    public DbSet<Recruiter> Recruiters { get; set;}

    public DbSet<Sourcer> Sourcers { get; set; }

    public DbSet<Manager> Managers { get; set; }

    public DbSet<Candidate> Candidates { get; set; }
}
