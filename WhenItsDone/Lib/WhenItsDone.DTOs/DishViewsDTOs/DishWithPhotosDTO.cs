using System.Collections.Generic;
using WhenItsDone.DTOs.PhotoItemDTOs;

namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishWithPhotosDTO
    {
        public int Id { get; set; }

        public ICollection<PhotoItemDTO> Photos { get; set; }
    }
}
