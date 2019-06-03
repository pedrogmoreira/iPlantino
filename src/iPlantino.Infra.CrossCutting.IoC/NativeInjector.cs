using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Authentication;
using iPlantino.Domain.Interfaces;
using iPlantino.Infra.CrossCutting.Bus;
using iPlantino.Infra.CrossCutting.Jwt;
using iPlantino.Infra.CrossCutting.Jwt.Models;
using iPlantino.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Alexinea.Autofac.Extensions.DependencyInjection;
using System;
using iPlantino.Infra.CrossCutting.Identity.Security;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NativeInjector
    {
        public static IServiceProvider RegisterServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();

            services.AddMediatR(typeof(NativeInjector));

            builder.ConfigureCore();

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

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureIdentityOptions();
        }

        private static void ConfigureJwt(this ContainerBuilder builder)
        {
            builder.RegisterType<JwtAutenticationService>()
                .InstancePerLifetimeScope();
        }
    }
}
