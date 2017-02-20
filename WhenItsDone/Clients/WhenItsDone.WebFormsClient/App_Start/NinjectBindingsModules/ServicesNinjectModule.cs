using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Linq;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssemblyId>()
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface()
                .Configure(y => y.InRequestScope())
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
        }

        private WorkerDetailInformationDTO GetWorkerDetailInformationDTO(IContext ctx)
        {
            var parameters = ctx.Parameters.ToList();

            var result = ctx.Kernel.Get<WorkerDetailInformationDTO>();
            result.Id = (int)parameters[0].GetValue(ctx, null);
            result.FirstName = (string)parameters[1].GetValue(ctx, null);
            result.LastName = (string)parameters[2].GetValue(ctx, null);
            result.Gender = (GenderType)parameters[3].GetValue(ctx, null);
            result.Age = (int)parameters[4].GetValue(ctx, null);
            result.Rating = (int)parameters[5].GetValue(ctx, null);
            result.Email = (string)parameters[6].GetValue(ctx, null);
            result.PhoneNumber = (string)parameters[7].GetValue(ctx, null);
            result.Country = (string)parameters[8].GetValue(ctx, null);
            result.City = (string)parameters[9].GetValue(ctx, null);
            result.Street = (string)parameters[10].GetValue(ctx, null);

            return result;
        }
    }
}