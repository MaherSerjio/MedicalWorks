using Assignment2.DTO;
using Assignment2.Models;
using AutoMapper;

namespace Assignment2.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Domain to Dto
            CreateMap<Beneficiary, BeneficiaryDTO>();
            CreateMap<Claim, ClaimDTO>();
            CreateMap<Policy, PolicyDTO>();

            //  Dto to Domain
            CreateMap<BeneficiaryDTO, Beneficiary>();
            CreateMap<ClaimDTO, Claim>();
            CreateMap<PolicyDTO, Policy>();
        }

    }
}
