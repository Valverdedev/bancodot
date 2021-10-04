using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using bancodot.Service;
using bancodot.Service.Abstractions;
using System;
using bancodot.Service.Services;
using Microsoft.OpenApi.Models;

namespace bancodot.application
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
         
            services.AddDbContext<MysqlContext>(options =>
            options.UseMySql(
                "server=localhost;port=3306;user=root;database=bancodot", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.20-mariadb")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
           services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IClientCreat , ClientCreat>();
            services.AddScoped<IClientSelect, ClientSelect>();
            services.AddScoped<IEmployeeCreat, EmployeeCreat>();
            services.AddScoped<IEmployeeSelect, EmployeeSelect>();
            services.AddScoped<IAgencyCreat, AgencyCreat>();
            services.AddScoped<IAgencySelect, AgencySelect>();
            services.AddScoped<IAccountCreat, AccountCreat>();
            services.AddScoped<IAccountSelect, AccountSelect>();
            services.AddScoped<GenereteEnrolmentEmployee>();
            services.AddScoped<GenerateAccountNumber>();
            services.AddSwaggerGen();

            services.AddControllers()

              .AddJsonOptions(p =>
              {
                  p.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                  p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

              });
              services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bancodot", Version = "v1" });
              })
                /*
                .AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

  )
          */
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ClientValidator>())
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<AccountValidator>())
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<AgencyValidator>())
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
            app.UseSwagger();

           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
