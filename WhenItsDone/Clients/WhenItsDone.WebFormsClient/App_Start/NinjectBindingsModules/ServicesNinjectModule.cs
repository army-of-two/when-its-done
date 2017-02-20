using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Linq;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        private string NameForBinding = "insideBinding";

        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssemblyId>()
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface()
                .Configure(y => y.InRequestScope())
            );

            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssemblyId>()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(z => z.InSingletonScope())
            );

            this.Kernel.Bind<WorkerDetailInformationDTO>().ToMethod(this.GetWorkerDetailInformationDTO)
               .NamedLikeFactoryMethod((IWorkerDetailInformationDTOFactory fac) =>
                                                   fac.GetWorkerDetailInformationDTO(default(int),
                                                                                       default(string),
                                                                                       default(string),
                                                                                       default(GenderType),
                                                                                       default(int),
                                                                                       default(int),
                                                                                       default(string),
                                                                                       default(string),
                                                                                       default(string),
                                                                                       default(string),
                                                                                       default(string)));


            //this.Kernel.Bind(x =>
            //    x.FromAssemblyContaining<IServicesAssemblyId>()
            //    .SelectAllInterfaces()
            //    .EndingWith("Mapper")
            //    .BindToFactory()
            //    .Configure(z => z.InSingletonScope())
            //    );

            //this.Bind<Worker>().ToMethod(this.MapWorker)
            //    .NamedLikeFactoryMethod((IDtoToWorkerMapper mapper) => mapper.GetWorker(null));
        }

        //private Worker MapWorker(IContext ctx)
        //{
        //    var dto = (WorkerDetailInformationDTO)ctx.Parameters.ToList()[0].GetValue(ctx, null);

        //    var worker = new Worker()
        //    {
        //        Id = dto.Id,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        Gender = dto.Gender,
        //        Age = dto.Age,
        //        Rating = dto.Rating
        //    };

        //    var contactInfo = ctx.Kernel.Get<ContactInformation>();
        //    worker.ContactInformation = contactInfo;

        //    contactInfo.Email = dto.Email;
        //    contactInfo.PhoneNumber = dto.PhoneNumber;

        //    var address = ctx.Kernel.Get<Address>();
        //    contactInfo.Address = address;

        //    address.City = dto.City;
        //    address.Country = dto.Country;
        //    address.Street = dto.Street;

        //    return worker;
        //}

        private WorkerDetailInformationDTO GetWorkerDetailInformationDTO(IContext ctx)
        {
            var parameters = ctx.Parameters.ToList();

            var result = new WorkerDetailInformationDTO
            {
                Id = (int)parameters[0].GetValue(ctx, null),
                FirstName = (string)parameters[1].GetValue(ctx, null),
                LastName = (string)parameters[2].GetValue(ctx, null),
                Gender = (GenderType)parameters[3].GetValue(ctx, null),
                Age = (int)parameters[4].GetValue(ctx, null),
                Rating = (int)parameters[5].GetValue(ctx, null),
                Email = (string)parameters[6].GetValue(ctx, null),
                PhoneNumber = (string)parameters[7].GetValue(ctx, null),
                Country = (string)parameters[8].GetValue(ctx, null),
                City = (string)parameters[9].GetValue(ctx, null),
                Street = (string)parameters[10].GetValue(ctx, null)
            };
            return result;
        }
    }
}