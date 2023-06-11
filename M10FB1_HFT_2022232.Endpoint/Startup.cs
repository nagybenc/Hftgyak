using M10FB1_HFT_2022232.Logic;
using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MusicDbContext>();

            services.AddTransient<IRepository<Label>, LabelRepository>();
            services.AddTransient<IRepository<Album>, AlbumRepository>();
            services.AddTransient<IRepository<Artist>, ArtistRepository>();

            services.AddTransient<ILabelLogic, LabelLogic>();
            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<IArtistLogic, ArtistLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "M10FB1_HFT_2022232.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "M10FB1_HFT_2022232.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x =>
                x.AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:24308")
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
