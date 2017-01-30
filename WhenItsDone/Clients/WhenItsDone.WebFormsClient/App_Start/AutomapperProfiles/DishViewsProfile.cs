using System.Linq;

using AutoMapper;

using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class DishViewsProfile : Profile
    {
        public DishViewsProfile()
        {
            this.CreateMap<Dish, NamePhotoDishView>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Recipe.Name))
                .ForMember(dest => dest.PhotoItemUrl, opts => opts.MapFrom(src => src.PhotoItems.FirstOrDefault().Url));
        }
    }
}