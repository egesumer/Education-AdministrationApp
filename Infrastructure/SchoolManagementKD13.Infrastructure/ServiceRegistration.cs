using Microsoft.Extensions.DependencyInjection;

using SchoolManagementKD13.Application.Enums;
using SchoolManagementKD13.Application.IServices;
using SchoolManagementKD13.Application.IToken;
using SchoolManagementKD13.Infrastructure.Services.FileServices;
using SchoolManagementKD13.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }

        //Factory pattern'e benzer bir yap kurguladık.
        public static void AddFileService(this IServiceCollection services, FileServiceType fileServiceType)
        {
            switch (fileServiceType)
            {
                case FileServiceType.Local:
                    services.AddScoped<IBaseFileService, LocalFileService>(); break;
                case FileServiceType.AWS:
                    services.AddScoped<IBaseFileService, LocalFileService>(); break;
                case FileServiceType.Azure:
                    services.AddScoped<IBaseFileService, LocalFileService>(); break;
                case FileServiceType.Google:
                    services.AddScoped<IBaseFileService, LocalFileService>(); break;
                default:
                    services.AddScoped<IBaseFileService, LocalFileService>(); break;
            }
        }
    }
}
