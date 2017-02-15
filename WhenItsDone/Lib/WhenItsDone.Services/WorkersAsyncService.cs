using System;
using System.Collections.Generic;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class WorkersAsyncService : GenericAsyncService<Worker>, IWorkersAsyncService, IGenericAsyncService<Worker>, IService
    {
        private readonly IWorkerAsyncRepository workerRepo;

        public WorkersAsyncService(IWorkerAsyncRepository repository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(repository, unitOfWorkFactory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("WorkerRepository");
            }

            this.workerRepo = repository;
        }

        public IEnumerable<WorkerNamesIdDTO> GetWorkersNamesAndId()
        {
            return this.workerRepo.GetWorkersNamesAndId().Result;
        }

        public WorkerDetailInformationDTO GetDetailInfoById(string id)
        {
            return this.workerRepo.GetDetailInfoById(id).Result;
        }
    }
}
