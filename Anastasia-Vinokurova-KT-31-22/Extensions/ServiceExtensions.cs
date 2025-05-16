using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Anastasia_Vinokurova_KT_31_22.Databases;
using Anastasia_Vinokurova_KT_31_22.Filters;
using Anastasia_Vinokurova_KT_31_22.Interfaces;
using Anastasia_Vinokurova_KT_31_22.Models;


namespace Anastasia_Vinokurova_KT_31_22.Extensions
{
    public static class ServiceExtensions
    { 
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {           
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
            });

            return services;
        }
    }
}