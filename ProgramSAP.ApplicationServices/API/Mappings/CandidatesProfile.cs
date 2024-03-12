using AutoMapper;
using ProgramSAP.ApplicationServices.API.Domain.Models;

namespace ProgramSAP.ApplicationServices.API.Mappings;

public class CandidatesProfile : Profile
{
    public CandidatesProfile()
    {
        this.CreateMap<ProgramSAP.DataAccess.Entities.Candidate, Candidate>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname));
    }
}
