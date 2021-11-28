using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SocialNetwork.API.Configurations;
using SocialNetwork.API.Filters;
using SocialNetwork.Common.Configurations;
using SocialNetwork.Domain.Mapping;
using SocialNetwork.Domain.Validations;
using SocialNetwork.Service.Mapping;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetwork.API
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<CustomExceptionFilter>();

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .AddFluentValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
                options.ImplicitlyValidateChildProperties = true;
            });

            // Add mediator
            services.RegisterMediatR();

            // Connect to database
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IDbConnection>((sp) => new SqlConnection(connectionString));

            // Add setting options
            services.Configure<JWTSetting>(Configuration.GetSection("JWTSetting"));
            services.Configure<PaginationSetting>(Configuration.GetSection("PaginationSetting"));
            services.Configure<EmailSetting>(Configuration.GetSection("EmailSetting"));

            // Add AutoMapper
            services.AddAutoMapper(typeof(ModelMapping).Assembly);

            // Add Dependency Injection
            services.RegisterRepositories();
            services.RegisterServices();

            // Add FluentValidation
            services.RegisterModelValidation();

            // Add JWT Config
            services.ConfigureJWT(Configuration);

            // Add Swagger
            services.ConfigureSwagger();

            // Add Api Versioning
            services.ConfigureApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    s.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }

                s.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
