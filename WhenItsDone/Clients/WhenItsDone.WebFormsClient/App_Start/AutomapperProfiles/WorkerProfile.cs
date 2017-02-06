using AutoMapper;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
            : base()
        {
            this.CreateMap<Worker, WorkerNamesIdDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(x => x.LastName));

            this.CreateMap<Worker, WorkerDetailInformationDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.AddressInformationId, opts => opts.MapFrom(x => x.ContactInformationId))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(x => x.Age))
                .ForMember(dest => dest.City, opts => opts.MapFrom(x => x.ContactInformation.Address.City))
                .ForMember(dest => dest.ContactInformationId, opts => opts.MapFrom(x => x.ContactInformationId))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(x => x.ContactInformation.Address.Country))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(x => x.ContactInformation.Email))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(x => x.Gender))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(x => x.ContactInformation.PhoneNumber))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(x => x.Rating))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(x => x.ContactInformation.Address.Street));

            this.CreateMap<Worker, WorkerWithDishesDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(x => x.Age))
                .ForMember(dest => dest.ContactInformation, opts => opts.MapFrom(x => x.ContactInformation))
                .ForMember(dest => dest.Dishes, opts => opts.MapFrom(x => x.Dishes))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(x => x.Gender))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(x => x.LastName))
                .ForMember(dest => dest.MedicalInformation, opts => opts.MapFrom(x => x.MedicalInformation))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(x => x.Rating));
        }
    }
}