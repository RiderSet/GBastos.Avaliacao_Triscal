using AutoMapper;
using CRUD.ApplicationCore.Interfaces.Repositories;
using CRUD.ApplicationCore.Interfaces.Services;
using CRUD.ApplicationCore.Services;
using CRUD.ApplicationCore.Validations;
using CRUD.InfraEstructure.Data.Contexts;
using CRUD.InfraEstructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRUD.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteValidation>());

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddFluentValidation();

            services.AddDbContext<Context>(options => {
                options.UseInMemoryDatabase("Avaliacao_GBastos");
            });

            //services.AddAutoMapper();

            services.AddScoped<ICliente_Rep, Cliente_Rep>();
            services.AddScoped<ICliente_SRV, Cliente_SRV>();

            services.AddScoped<IEndereco_Rep, Endereco_Rep>();
            services.AddScoped<IEndereco_SRV, Endereco_SRV>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
