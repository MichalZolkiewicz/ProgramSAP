using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class Candidate : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    public List<Requisition> Requisitions { get; set; }
}
