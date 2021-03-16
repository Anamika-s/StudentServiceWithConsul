using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>
               (p => new ConsulClient(consulConfig =>
               {

                   consulConfig.Address = new Uri("http://localhost:8500");

               }));
            return services;

        }
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app,
            IConfiguration configurationSetting)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                //ID = configurationSetting.GetValue<string>("ServiceName:Configuration"),
                //Name = configurationSetting.GetValue<string>("ServiceName:Configuration"),
                //Address = configurationSetting.GetValue<string>("ServiceHost:Configuration"),
                //Port = configurationSetting.GetValue<int>("ServicePort:Configuraton")

                ID= "students",
                Name= "students",
                Address="localhost",
                Port = 58491
            };
            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
            lifetime.ApplicationStopping.Register(() =>

            {
                logger.LogInformation("UnRegistreing from Consul");
            });
            return app;
        }
    }
}