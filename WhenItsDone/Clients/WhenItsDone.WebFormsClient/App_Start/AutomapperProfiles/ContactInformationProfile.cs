using AutoMapper;
using WhenItsDone.DTOs.ContactInformationDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class ContactInformationProfile : Profile
    {
        public ContactInformationProfile()
            : base()
        {
            this.CreateMap<ContactInformation, ContactInformationFullWithNestedDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(x => x.PhoneNumber))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(x => x.Address));
        }
    }
}