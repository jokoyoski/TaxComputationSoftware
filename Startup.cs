using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Serilog;
using TaxComputation.Service;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationAPI.Models.CustomHandler;
using TaxComputationAPI.Repositories;
using TaxComputationAPI.Services;
using TaxComputationSoftware.Helpers;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Repositories;
using TaxComputationSoftware.Services;

namespace TaxComputationAPI
{
    public class Startup
    {

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(_configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(options =>
         {
             options.AddPolicy("SystemAdmin", policy =>
                  policy.Requirements.Add(new SystemAdminRequirment()));
         });

            services.AddControllers()
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IEmailService, EmailService>();


           // services.AddSingleton<AnnualService>();
            services.AddSingleton<AnnualCalculation>();

   
            services.AddSingleton<JobSchedule>((x) =>
            {

                var cronExpression = "0 */3 * * * ?";
                return new JobSchedule(jobType: typeof(AnnualCalculation), cronExpression: cronExpression);

            });

            services.AddHostedService<TimedHostedService>();


            services.AddHostedService<AnnualEmailNotificationBackgroundService>();
            

            services.AddHostedService<BackgroundJobService>();

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddMemoryCache();
            services.AddScoped<IBalancingAdjustmentRepository, BalancingAdjustmentRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IBalancingAdjustmentService, BalancingAdjustmentService>();
            services.AddSingleton<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IFixedAssetService, FixedAssetService>();
            services.AddScoped<IFixedAssetRepository, FixedAssetRepository>();
            services.AddScoped<ITrialBalanceRepository, TrialBalanceRepository>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<IUtilitiesService, UtilitiesService>();
            services.AddScoped<ITrialBalanceService, TrialBalanceService>();
            services.AddScoped<ITrialBalanceRepository, TrialBalanceRepository>();
            services.AddSingleton<IUtilitiesRepository, UtilitiesRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAuthorizationHandler, SystemAdminHandler>();
            services.AddScoped<ICapitalAllowanceService, CapitalAllowanceService>();
            services.AddScoped<ICapitalAllowanceRepository, CapitalAllowanceRepository>();
            services.AddScoped<IProfitAndLossService, ProfitAndLossService>();
            services.AddScoped<IProfitAndLossRepository, ProfitAndLossRepository>();
            services.AddScoped<IMinimumTaxRepository, MinimumTaxRepository>();
            services.AddScoped<IMinimumTaxService, MinimumTaxService>();
            services.AddScoped<IITLevyRepository, ITLevyRepository>();
            services.AddScoped<IITLevyService, ITLevyService>();
            services.AddScoped<IMailManagerService, MailManagerService>();
            services.AddScoped<IInvestmentAllowanceRepository, InvestmentAllowanceRepository>();
            services.AddScoped<IInvestmentAllowanceService, InvestmentAllowanceService>();
            services.AddScoped<IIncomeTaxRepository, IncomeTaxRepository>();
            services.AddScoped<IIncomeTaxService, IncomeTaxService>();
            services.AddScoped<IDeferredTaxRepository, DeferredTaxRepository>();
           services.AddScoped<IDeferredTaxService, DeferredTaxService>();
            services.AddSingleton<DatabaseManager>();
            services.Configure<ConnectionString>(_configuration.GetSection("ConnectionString"));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            services.AddSwaggerGen(options =>
           {
               options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
               {
                   Title = "Tax Computation Service API",
                   Version = "v2",
                   Description = "Sample service for Learner",
               });
               // define swagger docs and other options
               var securityScheme = new OpenApiSecurityScheme
               {
                   Name = "Authorization",
                   Description = "Enter JWT Bearer authorisation token",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.Http,
                   Scheme = "bearer", // must be lowercase!!!
                   BearerFormat = "Bearer {token}",
                   Reference = new OpenApiReference
                   {
                       Id = JwtBearerDefaults.AuthenticationScheme,
                       Type = ReferenceType.SecurityScheme
                   }
               };
               options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
               options.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
        // defines scope - without a protocol use an empty array for global scope
        { securityScheme, Array.Empty<string>() }
   });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Logging
            loggerFactory.AddSerilog();

            // app.UseHttpsRedirection ();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
           {
               //endpoints.MapControllers();
               endpoints.MapFallbackToController("Index", "Fallback");
           });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "TaxComputation Service"));
        }
    }
}