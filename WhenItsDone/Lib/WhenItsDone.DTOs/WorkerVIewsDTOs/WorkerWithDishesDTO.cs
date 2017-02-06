using System.Collections.Generic;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.ContactInformationDTOs;
using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.DTOs.MedicalInformationDTOs;

namespace WhenItsDone.DTOs.WorkerVIewsDTOs
{
    public class WorkerWithDishesDTO
    {
        public int Id { get; set; }

        public IEnumerable<DishBasicsInfoDTO> Dishes { get; set; }
    }
}
