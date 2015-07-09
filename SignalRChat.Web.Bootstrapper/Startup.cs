using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Owin;

namespace SignalRChat.Web.Bootstrapper
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Call our IoC static helper method to start the typical Autofac SignalR setup
            var container = IocConfig.RegisterDependencies();

            // Get your HubConfiguration. In OWIN, we create one rather than using GlobalHost
            var hubConfig = new HubConfiguration();

            // Sets the dependency resolver to be autofac.
            hubConfig.Resolver = new AutofacDependencyResolver(container);

            // OWIN SIGNALR SETUP:

            // Register the Autofac middleware FIRST, then the standard SignalR middleware.
            app.UseAutofacMiddleware(container);
            app.MapSignalR("/signalr", hubConfig);
        }
    }
}
