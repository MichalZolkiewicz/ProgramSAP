using AutoMapper;
using ProgramSAP.ApplicationServices.API.Domain.Candidate;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Update;

namespace ProgramSAP.ApplicationServices.API.Mappings;

public class CandidatesProfile : Profile
{
    public CandidatesProfile()
    {

        this.CreateMap<AddCandidateRequest, DataAccess.Entities.Candidate>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
            .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

        this.CreateMap<DataAccess.Entities.Candidate, Candidate>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname));

        this.CreateMap<UpdateCandidateRequest, DataAccess.Entities.Candidate>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.CandidateId))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));
    }
}
