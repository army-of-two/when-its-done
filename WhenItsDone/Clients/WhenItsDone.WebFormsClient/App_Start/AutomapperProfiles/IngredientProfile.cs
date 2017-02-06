using AutoMapper;
using WhenItsDone.DTOs.IngredientDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class IngredientProfile : Profile
    {
        protected IngredientProfile(string profileName)
            : base(profileName)
        {
            this.CreateMap<Ingredient, IngredientWithFoodIdAndNameDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Food, opts => opts.MapFrom(x => x.Food.Name))
                .ForMember(dest => dest.FoodId, opts => opts.MapFrom(x => x.Food.Id))
                .ForMember(dest => dest.MeasurementUnitType, opts => opts.MapFrom(x => x.Food.MeasurementUnitType))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(x => x.Quantity));
        }
    }
}