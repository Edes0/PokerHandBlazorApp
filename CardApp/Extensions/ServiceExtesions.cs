using AutoMapper;
using Contracts;
using DataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Services;

namespace CardApp.Extensions
{
    public static class ServiceExtensions
    {
        //public static void ConfigureLoggerService(this IServiceCollection services) =>
        //        services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureDataAccessManager(this IServiceCollection services) =>
                services.AddScoped<IDataAccessManager, DataAccessManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
                services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureAutoMapper(this IServiceCollection services) =>
                services.AddAutoMapper(typeof(Program));

        public static void ConfigureSqlDbContext(this IServiceCollection services,
                IConfiguration configuration) =>
                services.AddDbContext<SqlDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("SqlServerDbConnection")));
    }
}