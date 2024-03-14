using MediatR;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.ApplicationServices.API.Handlers.Recruiters;

public class GetRecruitersHandler : IRequestHandler<GetRecruitersRequest, GetRecruitersResponse>
{
    private readonly IRepository<Recruiter> recruiterRepository;

    public GetRecruitersHandler(IRepository<Recruiter> recruiterRepository)
    {
        this.recruiterRepository = recruiterRepository;
    }
    public async Task<GetRecruitersResponse> Handle(GetRecruitersRequest request, CancellationToken cancellationToken)
    {
        var recruiters = await recruiterRepository.GetAll();
        var domainRecruiters = recruiters.Select(x => new Domain.Models.Recruiter
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
        });

        var response = new GetRecruitersResponse
        {
            Data = domainRecruiters.ToList()
        };

        return response;
    }
}
