using StructureMap;
namespace UESTicketsProject.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.Assembly("UESTicketsProject.Data");                   
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
            return ObjectFactory.Container;
        }
    }
}