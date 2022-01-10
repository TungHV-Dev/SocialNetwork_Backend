using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace SocialNetwork.API.Configurations
{
    public static class SwaggerConfigAzureAD
    {
        public static void ConfigureSwaggerAzureAD(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basic Socical Network", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Basic Socical Network", Version = "v2" });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{Configuration["AzureAD:Instance"]}/{Configuration["AzureAD:TenantId"]}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"{Configuration["AzureAD:Instance"]}/{Configuration["AzureAD:TenantId"]}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { Configuration["AzureAD:Scope"], Configuration["AzureAD:ScopeDescription"] }
                            }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "oauth2",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                     }
                });


            });
        }
    }
}
