using AutoMapper;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class WorkerWithDishesViewProfile : Profile
    {
        public WorkerWithDishesViewProfile()
        {
            this.CreateMap<Worker, WorkerWithDishesDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(x => x.Gender))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(x => x.Age))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(x => x.Rating))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(x => x.ContactInformation.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(x => x.ContactInformation.PhoneNumber))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(x => x.ContactInformation.Address.Country))
                .ForMember(dest => dest.City, opts => opts.MapFrom(x => x.ContactInformation.Address.City))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(x => x.ContactInformation.Address.Street))
                .ForMember(dest => dest.Dishes, opts => opts.MapFrom(x => x.Dishes));
        }
    }
}