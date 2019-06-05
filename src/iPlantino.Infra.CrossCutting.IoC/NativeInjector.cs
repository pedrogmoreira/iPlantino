using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Authentication;
using iPlantino.Infra.CrossCutting.Bus;
using iPlantino.Infra.CrossCutting.Jwt;
using iPlantino.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autofac;
using Alexinea.Autofac.Extensions.DependencyInjection;
using System;
using iPlantino.Infra.CrossCutting.Identity.Security;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using iPlantino.Domain.CommandHandlers.Registration;
using iPlantino.Infra.Data.Repositories;
using iPlantino.Domain.CommandHandlers.Device;
using iPlantino.Domain.Device.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NativeInjector
    {
        public static IServiceProvider RegisterServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();

            services.AddMediatR(typeof(NativeInjector));

            builder.ConfigureCore();

            services.AddUserConfiguration(builder, configuration);

            services.ConfigureIdentity(builder, configuration);

            builder.ConfigureJwt();
            services.ConfigureJwtAuthorization();

            builder.Populate(services);
            return new AutofacServiceProvider(builder.Build());
        }

        private static void ConfigureCore(this ContainerBuilder container)
        {
            container.RegisterType<DomainNotificationHandler>()
                .As<INotificationHandler<DomainNotification>>()
                .InstancePerLifetimeScope();

            container.RegisterType<InMemoryBus>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();
        }

        private static void ConfigureIdentity(this IServiceCollection services, ContainerBuilder builder, IConfigurationRoot configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<IdentityContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("AzureServer")));

            builder.RegisterType<AccessManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Arduino>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureIdentityOptions();
        }

        private static void ConfigureJwt(this ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtAutenticationService>()
                .InstancePerLifetimeScope();
        }

        public static IServiceCollection AddUserConfiguration(this IServiceCollection services, ContainerBuilder container, IConfigurationRoot configuration)
        {
            container.RegisterType<UnitOfWork<IdentityContext>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            container.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
               .Where(t => t.Namespace.EndsWith("Repositories"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AzureServer")));

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DeviceContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AzureServer")));

            //Commands Handlers
            container.RegisterType<RegisterUserCommandHandler>().AsImplementedInterfaces().InstancePerDependency();
            container.RegisterType<AddDeviceCommandHandler>().AsImplementedInterfaces().InstancePerDependency();

            return services;
        }
    }
}
