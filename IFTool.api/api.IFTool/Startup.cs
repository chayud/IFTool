using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.IFTool.Models;
using api.IFTool.Repositories;
using api.IFTool.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace api.IFTool
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private IHostingEnvironment _hostingEnv;
        public Startup(IHostingEnvironment env)
        {


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true,reloadOnChange:true)
                .AddEnvironmentVariables();

            _hostingEnv = env;

            if (string.IsNullOrWhiteSpace(_hostingEnv.WebRootPath))
            {
                _hostingEnv.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            //Configuration = configuration;
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "OSOnline Swaggered API",
                    Version = "v1",
                    Description = "My ASP.Net Core Swaggered API for OSOnline application purposes."
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //var xmlPath = Path.Combine(basePath, "swagger-training.xml");
                //options.IncludeXmlComments(xmlPath);
            });

            DapperExtensions.DapperExtensions.DefaultMapper = typeof(Repositories.DapperClassMapper.CustomAutoClassMapper<>);
            DapperExtensions.DapperAsyncExtensions.DefaultMapper = typeof(Repositories.DapperClassMapper.CustomAutoClassMapper<>);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/", "https://localhost:4200/","http://*.apthai.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            

            

            services.AddMemoryCache();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMasterRepository, MasterRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,IMasterRepository master)
        {

            //var conn = configuration.GetSection("ConnSettings.conn");

            var conn = Environment.GetEnvironmentVariable("ConnectionString");

            //var x = Environment.GetEnvironmentVariable("ConnectionString");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseSwagger();


            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();

            List<string> APIKey = Configuration.GetSection("AppSettings:APIKey").Value.Split(",").ToList();
            List<string> APIHeader = Configuration.GetSection("AppSettings:APIHeader").Value.Split(",").ToList();

            for (int i = 0; i < APIHeader.Count(); i++)
            {
                KeyAndTokenObject obj = new KeyAndTokenObject();
                obj.ApiHeader = APIHeader[i].ToString();
                obj.ApiKey = APIKey[i].ToString();
                KeyAndTokenExtention.KeyAndTokenProvider.Add(obj);
            }

            ProviderServiceUtil.Configuration = configuration;
            AppSettingServiceProvider.UseHeaderVerification = Configuration.GetSection("AppSettings:UseHeaderVerification").Value;
            AppSettingServiceProvider.IsProduction = Configuration.GetSection("AppSettings:IsProduction").Value;
            AppSettingServiceProvider.IsMailTo = Configuration.GetSection("AppSettings:IsMailTo").Value;
            AppSettingServiceProvider.DirRoot = Configuration.GetSection("AppSettings:DirRoot").Value;
            AppSettingServiceProvider.ZipPath = Configuration.GetSection("AppSettings:ZipPath").Value;
            AppSettingServiceProvider.StroageID = Configuration.GetSection("AppSettings:StorageID").Value;
            AppSettingServiceProvider.AuthorizeAPIKey = Configuration.GetSection("AppSettings:AuthorizeAPIKey").Value;
            AppSettingServiceProvider.AuthorizeAPIToken = Configuration.GetSection("AppSettings:AuthorizeAPIToken").Value;
            AppSettingServiceProvider.AuthorizeAPIUrl = Configuration.GetSection("AppSettings:AuthorizeAPIUrl").Value;
            AppSettingServiceProvider.MailAPIUrl = Configuration.GetSection("AppSettings:MailAPIUrl").Value;

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
            });            
        }
    }
}
