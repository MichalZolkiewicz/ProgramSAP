using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class Sourcer : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }
    public int? SeniorityLevel { get; set; }

    [MaxLength(250)]
    public string? AreaOfExpertise { get; set; }

    public List<Requisition> Requisition { get; set; }
}
