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

namespace iPlantino.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<iPlantinoContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("AzureServer")));

            services.AddUnitOfWork<iPlantinoContext>();

            services.AddMediatR(typeof(NativeInjector));

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<JwtAutenticationService>();

            services.AddScoped<AuthenticationService>();
        }
    }
}
