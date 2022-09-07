using Autofac;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieReviews.Configurations;
using MovieReviews.Database;
using MovieReviews.GraphQL;
using MovieReviews.Models;
using System.Text;

namespace MovieReviews
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

            //services
            //    .AddEntityFrameworkInMemoryDatabase()
            //    .AddDbContext<ApplicationContext>(context => { context.UseInMemoryDatabase("MovieDb"); });



            services.AddSingleton(Configuration.GetSection("AppConfiguration").Get<AppConfiguration>());
            services.AddSingleton(Configuration.GetSection("JwtSettings").Get<JwtSettings>());


            services.AddDbContext<ApplicationContext>(options =>
                   options.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString")));
                  // .AddTransient<IDatabaseSeeder, DatabaseSeeder>());

            services.AddIdentity<User, UserType>(options => { options.SignIn.RequireConfirmedAccount = false; })
                   .AddEntityFrameworkStores<ApplicationContext>()
                   .AddDefaultTokenProviders();

            // Adding Authorization
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            }
            );
            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
                };
            });


           

            services
                .AddGraphQL(
                    (options, provider) =>
                    {
                        // Load GraphQL Server configurations
                        var graphQLOptions = Configuration
                            .GetSection("GraphQL")
                            .Get<GraphQLOptions>();
                        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                        options.EnableMetrics = graphQLOptions.EnableMetrics;
                        // Log errors
                        var logger = provider.GetRequiredService<ILogger<Startup>>();
                        options.UnhandledExceptionDelegate = ctx =>
                            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    })
                // Adds all graph types in the current assembly with a singleton lifetime.
                .AddGraphTypes()
                // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
                .AddDataLoader()
                .AddSystemTextJson();
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();

            builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
            builder.RegisterType<MovieReviewSchema>().AsSelf().SingleInstance();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<MovieReviewSchema>();
            // Enables Altair UI at path /
            app.UseGraphQLAltair(new GraphQLAltairOptions {Path = "/"});

            app.UseHttpsRedirection();
        }
    }
}