﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuitarTabsAndChords.WebAPI.Database;
using GuitarTabsAndChords.WebAPI.Filters;
using GuitarTabsAndChords.WebAPI.Security;
using GuitarTabsAndChords.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GuitarTabsAndChords.WebAPI
{
    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }

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
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
#pragma warning disable CS0618 // Type or member is obsolete
            services.AddAutoMapper();
#pragma warning restore CS0618 // Type or member is obsolete

            services.AddScoped<IArtistsService, ArtistsService>();
            services.AddScoped<IAlbumsService, AlbumsService>();
            services.AddScoped<ISongsService, SongsService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<INotationsService, NotationsService>();
            services.AddScoped<INotationCorrectionsService, NotationCorrectionsService>();
            services.AddScoped<IRatingsService, RatingsService>();
            services.AddScoped<IFavoritesService, FavoritesService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IRecommenderService, RecommenderService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GuitarTabsAndChords API v1", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var connection = Configuration.GetConnectionString("lokalni");
            //var connection = Configuration.GetConnectionString("localDB");
            services.AddDbContext<GuitarTabsContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "GuitarTabsAndChords API v1");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
