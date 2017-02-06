using AutoMapper;
using WhenItsDone.DTOs.MedicalInformationDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class MedicalInformationProfile : Profile
    {
        public MedicalInformationProfile()
            : base()
        {
            this.CreateMap<MedicalInformation, MedicalInformationFullDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.BMI, opts => opts.MapFrom(x => x.BMI))
                .ForMember(dest => dest.BustSizeInCm, opts => opts.MapFrom(x => x.BustSizeInCm))
                .ForMember(dest => dest.HeightInCm, opts => opts.MapFrom(x => x.HeightInCm))
                .ForMember(dest => dest.HipSizeInCm, opts => opts.MapFrom(x => x.HipSizeInCm))
                .ForMember(dest => dest.WaistSizeInCm, opts => opts.MapFrom(x => x.WaistSizeInCm))
                .ForMember(dest => dest.WeightInKg, opts => opts.MapFrom(x => x.WeightInKg));
        }
    }
}