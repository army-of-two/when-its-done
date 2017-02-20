using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.Services
{
    public class WorkersAsyncService : GenericAsyncService<Worker>, IWorkersAsyncService, IGenericAsyncService<Worker>, IService
    {
        private readonly IWorkerAsyncRepository workerRepo;
        //private readonly IDtoToWorkerMapper DtoToWorkerMapper;

        public WorkersAsyncService(IWorkerAsyncRepository repository, IDisposableUnitOfWorkFactory unitOfWorkFactory
                                       /* , IDtoToWorkerMapper DtoToWorkerMapper*/)
            : base(repository, unitOfWorkFactory)
        {
            Guard.WhenArgument(repository, "IWorkerAsyncRepository").IsNull().Throw();
            //Guard.WhenArgument(DtoToWorkerMapper, "IDtoToWorkerMapper").IsNull().Throw();

            this.workerRepo = repository;
            //this.DtoToWorkerMapper = DtoToWorkerMapper;
        }

        public IEnumerable<WorkerNamesIdDTO> GetWorkersNamesAndId()
        {
            return this.workerRepo.GetWorkersNamesAndId().Result;
        }

        public WorkerDetailInformationDTO GetDetailInfoById(string id)
        {
            return this.workerRepo.GetDetailInfoById(id).Result;
        }

        public string UpdateWorkerDetailInformationDTO(WorkerDetailInformationDTO worker)
        {
            string result = "Update fail";

            //var mapped = this.DtoToWorkerMapper.GetWorker(worker);

            try
            {
                using (var uow = this.UnitOfWorkFactory.CreateUnitOfWork())
                {
                    var original = this.workerRepo.GetByIdAsync(worker.Id).Result;

                    if (original == null)
                    {
                        throw new ArgumentException("Invalid Id");
                    }

                    original.FirstName = worker.FirstName;
                    original.LastName = worker.LastName;
                    original.Age = worker.Age;
                    original.Gender = worker.Gender;
                    original.Rating = worker.Rating;

                    original.ContactInformation.PhoneNumber = worker.PhoneNumber;
                    original.ContactInformation.Email = worker.Email;

                    original.ContactInformation.Address.City = worker.City;
                    original.ContactInformation.Address.Street = worker.Street;
                    original.ContactInformation.Address.Country = worker.Country;

                    this.workerRepo.Update(original);
                    uow.SaveChanges();
                }
                result = "Save success";
            }
            catch (SqlException) { }

            return result;
        }
    }
}
