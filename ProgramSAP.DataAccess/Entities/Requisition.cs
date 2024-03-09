using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class Requisition : EntityBase
{
    public int RecruiterId { get; set; } 

    public Recruiter Recruiter { get; set; }

    public int ManagerId { get; set; }

    public Manager Manager { get; set; }

    public int CandidateId { get; set; }

    public Candidate Candidate { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }

    public int JobLevel { get; set; }

    public List<Sourcer> Sourcers { get; set; }

}
