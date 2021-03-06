﻿using AutoMapper;
using WhenItsDone.DTOs.IngredientDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class IngredientProfile : Profile
    {
        protected IngredientProfile(string profileName)
            : base(profileName)
        {
            this.CreateMap<Ingredient, IngredientWithNamesDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.FoogId, opts => opts.MapFrom(x => x.FoodId))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(x => x.Food.Name))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(x => x.Quantity));
        }
    }
}