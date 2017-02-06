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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public int Age { get; set; }

        public int Rating { get; set; }

        public MedicalInformationFullDTO MedicalInformation { get; set; }

        public ContactInformationFullWithNestedDTO ContactInformation { get; set; }

        public IEnumerable<DishWithRecipeAndPhotosDTO> Dishes { get; set; }
    }
}
