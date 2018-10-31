using StructureMap;
using System.Web.Mvc;
using UESTicketsProject.DependencyResolution;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UESTicketsProject.WebApplication.App_Start.StructuremapMvc), "Start")]

namespace UESTicketsProject.WebApplication.App_Start
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            var container = (IContainer)IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}