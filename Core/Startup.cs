using Core.Features;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;


public class CoreStartUp { }
public static class DependencyInject
{
    public static void InjectCore(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        //services.AddScoped<SiteRegistrationService>();
    }
}
