void OfcBetterNameHere (IKernel kernel)
{
    kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
    kernel.Bind<IWhenItsDoneDbContext>().To<WhenItsDoneDbContext>().InRequestScope();
    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

    kernel.Bind(x => x.From( /* Assemblies here */ )
                            .SelectAllClasses()
                            .InheritedFrom<IService>()
                            .BindDefaultInterface()
                            .Configure(z => z.InRequestScope()));
}