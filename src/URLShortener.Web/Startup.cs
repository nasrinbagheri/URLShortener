using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.DataAccess;
using URLShortener.DataAccess.Contracts;
using URLShortener.DataAccess.Repositories;
using URLShortener.DataAccess.Services;
using URLShortener.Encryption;
using URLShortener.Encryption.Contracts;
using URLShortener.IntegrationService;
using URLShortener.IntegrationService.Contracts;
using URLShortener.Web.Mapping;
using URLShortener.Web.MiddleWares;

namespace URLShortener.Web
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
            services.AddOptions();
            services.Configure<HashIdOptions>(Configuration.GetSection("HashIdOptions"))
                .Configure<URlShortenerOptions>(Configuration.GetSection("URlShortenerOptions"));

            services.AddScoped<IDbContext, DataAccessContext>();
            services.AddDbContext<DataAccessContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ILinkTicketService, LinkTicketService>();
            services.AddSingleton<IHashIdService, HashIdService>();
            services.AddScoped<IURlShortenerService, URlShortenerService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(err => err.UseCustomErrors());

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                   "/{*code}",
                   new { controller = "Home", action = "Index" }
               );
            });


        }
    }
}
