using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;

using WhenItsDone.Data;
using WhenItsDone.Data.AssemblyId;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Factories;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Data.UnitsOfWork;
using WhenItsDone.Models;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using Ninject.Activation;
using Ninject;
using System.Linq;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IDataAssemblyId>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IDataAssemblyId>()
                .SelectAllInterfaces()
                .EndingWith("Mapper")
                .BindToFactory()
                .Configure(z => z.InSingletonScope())
                );

            this.Bind<IDisposableUnitOfWork>().To<UnitOfWork>();

            this.Bind<IDisposableUnitOfWorkFactory>()
                .ToFactory()
                .InRequestScope();

            this.Rebind<IWhenItsDoneDbContext>()
                .To<WhenItsDoneDbContext>()
                .InRequestScope();

            this.Bind<IStatefulFactory>().ToFactory().InSingletonScope();

            this.Bind<Worker>().ToMethod(this.MapWorker)
                .NamedLikeFactoryMethod((IDtoToWorkerMapper mapper) => mapper.GetWorker(null));
        }

        private Worker MapWorker(IContext ctx)
        {
            var dto = (WorkerDetailInformationDTO)ctx.Parameters.ToList().FirstOrDefault();

            var worker = ctx.Kernel.Get<Worker>();
            worker.Id = dto.Id;
            worker.FirstName = dto.FirstName;
            worker.LastName = dto.LastName;
            worker.Gender = dto.Gender;
            worker.Age = dto.Age;
            worker.Rating = dto.Rating;

            var contactInfo = ctx.Kernel.Get<ContactInformation>();
            worker.ContactInformation = contactInfo;

            contactInfo.Email = dto.Email;
            contactInfo.PhoneNumber = dto.PhoneNumber;

            var address = ctx.Kernel.Get<Address>();
            contactInfo.Address = address;

            address.City = dto.City;
            address.Country = dto.Country;
            address.Street = dto.Street;

            return worker;
        }
    }
}