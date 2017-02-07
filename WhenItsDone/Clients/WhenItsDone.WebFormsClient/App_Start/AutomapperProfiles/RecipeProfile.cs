using AutoMapper;
using WhenItsDone.DTOs.RecipeDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class RecipeProfile : Profile
    {
        protected RecipeProfile(string profileName)
            : base(profileName)
        {
            this.CreateMap<Recipe, RecipeWithIngredientsDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Ingradients, opts => opts.MapFrom(x => x.Ingredients));
        }
    }
}