using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain.Candidate.Update;

public class UpdateCandidateRequest : IRequest<UpdateCandidateResponse>
{
    public int CandidateId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
