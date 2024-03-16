using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;

public class AddCandidateRequest : IRequest<AddCandidateRespone>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
