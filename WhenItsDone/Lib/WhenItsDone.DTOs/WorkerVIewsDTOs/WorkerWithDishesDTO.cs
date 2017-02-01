using System.Collections.Generic;
using WhenItsDone.Models;

namespace WhenItsDone.DTOs.WorkerVIewsDTOs
{
    public class WorkerWithDishesDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
    }
}
