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
        private readonly IDbModelFactory modelFactory;

        private readonly IAsyncRepository<ContactInformation> contactsRepo;
        private readonly IAsyncRepository<Address> addressRepo;

        public WorkersAsyncService(IWorkerAsyncRepository repository,
                                    IDisposableUnitOfWorkFactory unitOfWorkFactory,
                                    IDbModelFactory modelFactory,
                                    IAsyncRepository<ContactInformation> contactsRepo,
                                    IAsyncRepository<Address> addressRepo)
            : base(repository, unitOfWorkFactory)
        {
            Guard.WhenArgument(repository, "IWorkerAsyncRepository").IsNull().Throw();
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();
            Guard.WhenArgument(contactsRepo, "contactsRepo").IsNull().Throw();
            Guard.WhenArgument(addressRepo, "addressRepo").IsNull().Throw();

            this.workerRepo = repository;
            this.modelFactory = modelFactory;

            this.contactsRepo = contactsRepo;
            this.addressRepo = addressRepo;
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

                    if (original.ContactInformation == null)
                    {
                        var contacts = this.modelFactory.GetEmptyDbModel<ContactInformation>();

                        this.contactsRepo.Add(contacts);

                        original.ContactInformation = contacts;
                    }

                    original.ContactInformation.PhoneNumber = worker.PhoneNumber;
                    original.ContactInformation.Email = worker.Email;

                    if (original.ContactInformation.Address == null)
                    {
                        var address = this.modelFactory.GetEmptyDbModel<Address>();

                        this.addressRepo.Add(address);

                        original.ContactInformation.Address = address;
                    }

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
