using System.ComponentModel.DataAnnotations;

namespace ProgramSAP.DataAccess.Entities;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}
