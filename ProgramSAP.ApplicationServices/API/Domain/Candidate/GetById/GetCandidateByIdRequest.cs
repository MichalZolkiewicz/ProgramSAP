using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain.Candidate.GetById;

public class GetCandidateByIdRequest : IRequest<GetCandidateByIdResponse>
{
    public int CandidateId { get; set; }    
}
