using AutoMapper;
using WhenItsDone.DTOs.PhotoItemDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles
{
    public class PhotoItemProfile : Profile
    {
        public PhotoItemProfile()
            : base()
        {
            this.CreateMap<PhotoItem, PhotoItemDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(x => x.Url));
        }
    }
}