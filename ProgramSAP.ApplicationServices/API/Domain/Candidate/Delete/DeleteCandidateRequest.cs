using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain.Candidate.Delete;

public class DeleteCandidateRequest : IRequest<DeleteCandidateResponse>
{
    public int CandidateId { get; set; }
}
