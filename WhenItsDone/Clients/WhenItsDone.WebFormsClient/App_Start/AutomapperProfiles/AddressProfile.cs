using AutoMapper;
using WhenItsDone.DTOs.AddressDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class AddressProfile : Profile
    {
        protected AddressProfile(string profileName)
            : base(profileName)
        {
            this.CreateMap<Address, AddressFullDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(x => x.Country))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(x => x.Street))
                .ForMember(dest => dest.City, opts => opts.MapFrom(x => x.City));
        }
    }
}