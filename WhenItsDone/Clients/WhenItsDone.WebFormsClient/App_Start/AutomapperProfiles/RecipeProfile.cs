using AutoMapper;
using WhenItsDone.DTOs.RecipeDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
            : base()
        {
            this.CreateMap<Recipe, RecipeFullDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(x => x.Description))
                .ForMember(dest => dest.Ingredients, opts => opts.MapFrom(x => x.Ingredients));
        }
    }
}