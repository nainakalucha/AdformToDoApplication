using Assignment.Api.Core.Middleware;
using Assignment.Dal;
using Assignment.DAL.Core;
using Assignment.Framework.Core;
using AutoMapper;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Web;
using Newtonsoft.Json;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
           .AddGraphQL(s => SchemaBuilder.New()
           .AddServices(s)
           .AddType<PagingDtoType>()
           .AddQueryType<AssessmentQueryType>()
           .AddMutationType<Mutation>()
           .AddAuthorizeDirectiveType()
           .Create());

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddAutoMapper();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().AddXmlSerializerFormatters()           
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AssignmentSqlDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<Framework.Core.ILogger, NLogLogger>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            services.AddScoped<IToDoListService, ToDoListService>();

            services.AddScoped<IGenericRepository, GenericSQLRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.OperationFilter<AuthHeaderFilter>();
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AssignmentSqlDbContext>();
                context.Database.EnsureCreated();
            }

            app.UseGraphQL();
            app.UsePlayground();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.AddNLogWeb();
            env.ConfigureNLog("NLog.config");
            app.UseMiddleware<ExceptionMiddleware>();
            loggerFactory.AddNLog();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
