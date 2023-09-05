using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.DAL.DBContext;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DAL.Repository;
using SystemEmail.Utility;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.BLL.Services;

namespace SystemEmail.IOC
{
    public static class Dependence
    {
        //metodo de extension.
        public static void InjectDependences(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbemailContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("stringSQL"));
            });


            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IEmailRepository, EmailRepository>();


            services.AddAutoMapper(typeof(AutoMapperProfile));


            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDashBoardService , DashBoardService>();

        
        }




    }
}
