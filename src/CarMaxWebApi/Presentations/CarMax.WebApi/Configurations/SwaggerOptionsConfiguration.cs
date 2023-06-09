﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CarMax.WebApi.Configurations
{
    public class SwaggerOptionsConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in provider.ApiVersionDescriptions
                .Where(d => !string.IsNullOrWhiteSpace(d.GroupName)))
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }
        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();

            var info = new OpenApiInfo()
            {
                Title = $"CarMax Api v{assembly?.Version?.ToString()} ",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

    }
}
