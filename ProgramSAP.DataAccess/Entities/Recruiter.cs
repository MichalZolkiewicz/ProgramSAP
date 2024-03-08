using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class Recruiter : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }

    public int SeniorityLevel { get; set; }

    public List<Requisition> Requisitions { get; set; }
}
