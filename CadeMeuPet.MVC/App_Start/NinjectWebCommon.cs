using CadeMeuPet.Domain.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CadeMeuPet.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CadeMeuPet.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CadeMeuPet.MVC.App_Start
{
    using System;
    using System.Web;
    using CadeMeuPet.Data.Repositories;
    using CadeMeuPet.Domain.Interfaces.Services;
    using CadeMeuPet.Domain.Services;
    using CadeMeuPet.Domain.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                    new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
                                
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
                   
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IServiceEspecieAnimal>().To<ServiceEspecieAnimal>();
            kernel.Bind<IServiceRacaAnimal>().To<ServiceRacaAnimal>();
            kernel.Bind<IServiceCorAnimal>().To<ServiceCorAnimal>();
            kernel.Bind<IServicePorteAnimal>().To<ServicePorteAnimal>();
            kernel.Bind<IServiceLocalizacao>().To<ServiceLocalizacao>();
            kernel.Bind<IServiceCidade>().To<ServiceCidade>();
            kernel.Bind<IServiceEstado>().To<ServiceEstado>();
            kernel.Bind<IServiceUsuario>().To<ServiceUsuario>();
            kernel.Bind<IServiceAnimal>().To<ServiceAnimal>();
            kernel.Bind<IServiceFotos>().To<ServiceFotos>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IRepositoryEspecieAnimal>().To<RepositoryEspecieAnimal>();
            kernel.Bind<IRepositoryRacaAnimal>().To<RepositoryRacaAnimal>();
            kernel.Bind<IRepositoryCorAnimal>().To<RepositoryCorAnimal>();
            kernel.Bind<IRepositoryPorteAnimal>().To<RepositoryPorteAnimal>();
            kernel.Bind<IRepositoryLocalizacao>().To<RepositoryLocalizacao>();
            kernel.Bind<IRepositoryCidade>().To<RepositoryCidade>();
            kernel.Bind<IRepositoryEstado>().To<RepositoryEstado>();
            kernel.Bind<IRepositoryUsuario>().To<RepositoryUsuario>();
            kernel.Bind<IRepositoryAnimal>().To<RepositoryAnimal>();
            kernel.Bind<IRepositoryFoto>().To<RepositoryFotos>();
        }        
    }
}
