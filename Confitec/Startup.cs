using Confitec.Core.Configuracoes;
using Confitec.Core.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositorio.Contexto;
using System.Text.Json.Serialization;

namespace Confitec
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
            services.AddAplicacaoIoC();
            services.AddCrosscutingIoC();
            services.AddRepositorioIoC(Configuration);
            services.AddServiceIoC();
            services.AddAutoMapper(GetType().Assembly);
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddCors(options => options.AddPolicy("CorsOptions", x =>
                                                x.AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials()
                                                .WithOrigins("http://localhost:4200")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Confitec", Version = "v1" });
            });
            services.AddODataCustom();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConfitecContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Confitec v1"));
            }
            app.UseCors("CorsOptions");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                ODataConfig.UseODataCustom(endpoints);
            });
        }
    }
}
