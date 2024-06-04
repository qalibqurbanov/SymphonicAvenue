﻿using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SymphonicAvenue.WebAPI.Extensions
{
    /// <summary>
    /// UI qatinin IoC-ye elave etmeli oldugu servisleri elave eden metodlari saxlayir.
    /// </summary>
    public static class RegisterServices
    {
        /// <summary>
        /// IoC Container-a UI qatinin servislerini elave edir.
        /// </summary>
        public static IServiceCollection RegisterUIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    /* Appimizin dondureceyi json neticenin 'null' olan uzvlerini return etme: */
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

                    /* Aralarinda 2 terefli elaqe olan entitylerin serializasiyasi zamani "A possible object cycle was detected..." xetasi yaranir. Helli ucun naviqasiyani/referansi propertysini serializasiyadan gizledirik: */
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.AddSwaggerGen(options =>
            {
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "SymphonicAvenue",
                        Description = "API backend supporting CRUD and more.",
                        TermsOfService = new Uri("https://numune.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Elaqe",
                            Url = new Uri("https://numune.com/contact")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Lisenziya",
                            Url = new Uri("https://numune.com/license")
                        }
                    });
                }

                {
                    /* Controllerdeki dokumentasiyalar hansi fayla yazilib ve hansi fayldan oxunsun ('Swagger UI'-da gosterilmesi ucun)?: */
                    Assembly apiAssembly = typeof(Program).Assembly;
                    string documentationFileName = $"{apiAssembly.GetName().Name}.xml";
                    string documentationFilePath = Path.Combine(AppContext.BaseDirectory, documentationFileName);
                    options.IncludeXmlComments(documentationFilePath);
                }
            });

            // services.AddRouting(cfg =>
            services.Configure<RouteOptions>(cfg =>
            {
                cfg.LowercaseUrls = true;
                cfg.LowercaseQueryStrings = false; /* 'true' ola bilmesi ucun 'LowercaseUrls'-de 'true' set olunmalidir. Query String-de token ve s. gonderende ve ya qebul edende problem yaradir deye 'false' olsa yaxwidir. */
            });

            return services;
        }
    }
}
