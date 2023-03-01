using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain.Identity;
using SchoolManagementKD13.Persistence.Contexts;
using SchoolManagementKD13.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<SchoolManagementDbContext>(options => options.UseSqlServer(ConnectionStringsHelper.ConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<SchoolManagementDbContext>();

            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<ISchoolReadRepository, SchoolReadRepository>();
            services.AddScoped<ISchoolWriteRepository, SchoolWriteRepository>();


        }
    }
}
