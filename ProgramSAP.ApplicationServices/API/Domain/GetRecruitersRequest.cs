using MediatR;

namespace ProgramSAP.ApplicationServices.API.Domain;

public class GetRecruitersRequest : IRequest<List<Recruiter>>
{
}
