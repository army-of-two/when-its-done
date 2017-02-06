using System.Linq;

using AutoMapper;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class DishViewsProfile : Profile
    {
        public DishViewsProfile()
        {
            this.CreateMap<Dish, NamePhotoDishViewDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Recipe.Name))
                .ForMember(dest => dest.PhotoItemUrl, opts => opts.MapFrom(src => src.PhotoItems.FirstOrDefault().Url));

            this.CreateMap<Dish, NamePhotoRatingDishViewDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Recipe.Name))
                .ForMember(dest => dest.PhotoItemUrl, opts => opts.MapFrom(src => src.PhotoItems.FirstOrDefault().Url))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating));
        }
    }
}