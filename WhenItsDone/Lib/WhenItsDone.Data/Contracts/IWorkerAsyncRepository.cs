using System.Collections.Generic;
using System.Threading.Tasks;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IWorkerAsyncRepository : IAsyncRepository<Worker>
    {
        Task<IEnumerable<WorkerWithDishesDTO>> GetWorkersWithDishes();
    }
}
