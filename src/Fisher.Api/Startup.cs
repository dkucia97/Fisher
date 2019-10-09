using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Core.Services;
using Fisher.Core.Utilities;
using Fisher.Infrastructure.Auth;
using Fisher.Infrastructure.EF;
using Fisher.Infrastructure.Repositories;
using Fisher.Infrastructure.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Fisher.Api
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
            //TODO : add all dependencies ,mapper, validator ,jwt ,sql config 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            //settings
            services.Configure<SqlSettings>(Configuration.GetSection("Db"));
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            services.AddDbContext<FisherDbContext>(
                e=>
                {
                    var connectionString = Configuration.GetSection("Db")["ConnectionString"];
                    e.UseSqlServer(connectionString,
                        c=>c.MigrationsAssembly(typeof(FisherDbContext).Assembly.FullName));
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo()
            {
                 Title = "Fisher Api",
                 Description = "Application to create notes(flesh  cards) ," +
                               "store in account ,Publish and follow others packages ",
            }));
            // Jwt config
            var key = Configuration.GetSection("Jwt")["Key"];
            
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IEncrypter, Encrypter>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<INotesService, NotesService>();
            services.AddTransient<IUserNotesService, UserNotesServices>();
            services.AddTransient<IFileConverter<Note>, NotesFileConverter>();
            services.AddTransient<INoteFileStrategyResolver,NoteFileStrategyResolver>();
            services.AddTransient<INoteFileConverterStrategy,CsvFileConverter>();
            services.AddTransient<INoteFileConverterStrategy, TxtFileConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
        }
    }
}
