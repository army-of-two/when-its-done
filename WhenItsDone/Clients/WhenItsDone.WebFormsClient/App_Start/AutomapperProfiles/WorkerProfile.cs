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