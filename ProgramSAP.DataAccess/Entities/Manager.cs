using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class Manager : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(250)]
    public string Title { get; set; }

    public List<Requisition> Requisitions { get; set; }
}
