using System.Collections.Generic;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IWorkersAsyncService : IGenericAsyncService<Worker>
    {
        IEnumerable<WorkerNamesIdDTO> GetWorkersWithDIshes();
    }
}
