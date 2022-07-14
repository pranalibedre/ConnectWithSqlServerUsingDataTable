using DataRepository;
using Interfaces;
using Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DependacyResolver
{
    public static class ServiceModule
    {
        public static UnityContainer RegisterComponents()
        {
            return BuildUnityContainer();
        }

        public static void SetDependancyResolver(IUnityContainer container)
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static UnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //repositories
            //Dependancy resolution 
            container.BindInRequestScope<IPersonRepository, PersonRepository>();
            //container.BindInRequestScope<IPersonRepository, PersonOracleReporstory>();

            return container;
        }
    }
}