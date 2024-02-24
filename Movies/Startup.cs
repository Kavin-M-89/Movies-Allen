using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movies.BL;
using Movies.Entity;
using Movies.InterfaceBL;
using Movies.InterfaceRepo;
using Movies.Repository.QueryRepository;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies
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
            services.AddControllers();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IReportService, ReportService>();
            services.AddScoped<IMovieBL, MovieBL>();
            services.AddScoped<IActorBL, ActorBL>();
            services.AddScoped<IGenreBL, GenreBL>();
            services.AddScoped<IMoviePersonMappingQueryRepository, MoviePersonMappingQueryRepository>();
            services.AddScoped<IMovieQueryRepository, MovieQueryRepository>();
            services.AddScoped<IPersonQueryRepository, PersonQueryRepository>();
            services.AddScoped<IReviewQueryRepository, ReviewQueryRepository>();
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IGenreQueryRepository, GenreQueryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
