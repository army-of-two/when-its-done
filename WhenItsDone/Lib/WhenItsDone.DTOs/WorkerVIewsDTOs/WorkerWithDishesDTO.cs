using System.Collections.Generic;
using WhenItsDone.DTOs.DishViewsDTOs;

namespace WhenItsDone.DTOs.WorkerVIewsDTOs
{
    public class WorkerWithDishesDTO
    {
        public int Id { get; set; }

        public IEnumerable<DishBasicsInfoDTO> Dishes { get; set; }
    }
}
