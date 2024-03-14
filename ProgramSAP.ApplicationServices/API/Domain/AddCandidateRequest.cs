using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain;

public class AddCandidateRequest : IRequest<AddCandidateRespone>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
