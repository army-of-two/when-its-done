using AutoMapper;

using WhenItsDone.Models;
using WhenItsDone.DTOs.UserViewsDTOs;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class UserViewsProfile : Profile
    {
        public UserViewsProfile()
        {
            this.CreateMap<User, UsernameProfilePictureUserViewDTO>()
                .ForMember(destination => destination.Username, options => options.MapFrom(source => source.Username))
                .ForMember(destination => destination.ProfilePictureBase64, options => options.MapFrom(source => source.ProfilePicture.PictureBase64))
                .ForMember(destination => destination.ProfilePictureExtension, options => options.MapFrom(source => source.ProfilePicture.MimeType));

            this.CreateMap<User, MedicalInformationUserViewDTO>()
                .ForMember(destination => destination.HeightInCm, options => options.MapFrom(source => source.MedicalInformation.HeightInCm))
                .ForMember(destination => destination.WeightInKg, options => options.MapFrom(source => source.MedicalInformation.WeightInKg));
        }
    }
}