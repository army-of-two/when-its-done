using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Factories
{
    public interface IDtoToWorkerMapper
    {
        Worker GetWorker(WorkerDetailInformationDTO workerDTO);
    }
}
