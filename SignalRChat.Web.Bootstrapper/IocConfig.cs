using Autofac;
using Autofac.Integration.SignalR;
using SignalRChat.Web.Hubs;
using System.Reflection;

namespace SignalRChat.Web.Bootstrapper
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TestClass>();

            // Register your SignalR hubs.
            builder.RegisterHubs(Assembly.Load("SignalRChat.Web"));

            return builder.Build();
        }
    }
}
