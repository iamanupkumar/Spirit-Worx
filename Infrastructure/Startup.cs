using Core.Abratractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class InfrastructureStartup
{
}

public static class DependencyInject
{
    public static void InjectInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDBSession, DBSession>();
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<ISiteRegistrationRepository, SiteRegistrationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

