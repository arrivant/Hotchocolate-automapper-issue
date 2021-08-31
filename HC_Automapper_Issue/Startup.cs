using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using AutoMapper;
using HC_Automapper_Issue.DbContext;
using HC_Automapper_Issue.GraphQL;
using HC_Automapper_Issue.Services;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Options;
using Microsoft.EntityFrameworkCore;

namespace HC_Automapper_Issue
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
            services.AddHttpContextAccessor();

            services.AddAuthorization();

            services.AddTransient<IConnectionStringService, ConnectionStringService>();

            services.AddPooledDbContextFactory<CustomerDbContext>((provider, optionsBuilder) =>
            {
                var connectionStringService = provider.GetService<IConnectionStringService>();
                var connectionString = connectionStringService?.GetDbConnectionString();
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new Exception("Could not obtain connection string!");
                }

                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Trace);
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddGraphQLServer()
                .ModifyRequestOptions(x =>
                {
                    x.IncludeExceptionDetails = true;
                    x.ExecutionTimeout = TimeSpan.FromMinutes(1);
                })
                .AddQueryType(descriptor => descriptor.Name(RootQuery.Name))
                .AddTypeExtension<AllQueries>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddApolloTracing(TracingPreference.OnDemand, new DefaultTimestampProvider());//this is like that as default, i've just added it to remember
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            ValidateMappingProfiles(mapper);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/graphql", permanent: false);
                    return Task.CompletedTask;
                });
                endpoints.MapGraphQL();
            });
        }

        private static void ValidateMappingProfiles(IMapper mapper)
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
