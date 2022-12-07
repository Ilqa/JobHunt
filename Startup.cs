using JobHunt.Configurations;
using JobHunt.Database;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JobHunt
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services
            //    .AddEntityFrameworkInMemoryDatabase()
            //    .AddDbContext<ApplicationContext>(context => { context.UseInMemoryDatabase("MovieDb"); });


            AddRepositoriesAndServices(services);

            //services.AddSingleton(Configuration.GetSection("AppConfiguration").Get<AppConfiguration>());
            //services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            //services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            // services.AddSingleton(Configuration.GetSection("JwtSettings").Get<JwtSettings>());

            services.AddControllers();

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy(
                                name: "AllowOrigin",
                                builder => { builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
            });

            services.AddDbContext<ApplicationContext>(options =>
                   options.UseNpgsql("Server=localhost;Port=5432;Database=WorkForce;User Id=postgres;Password=floodee;"))  //Configuration.GetConnectionString("DefaultConnectionString"))
                   .AddTransient<IDatabaseSeeder, DatabaseSeeder>();

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
                    ValidIssuer = "JobHunt.Api", //Configuration["JwtSettings:Issuer"],
                    ValidAudience = "JobHunt.Api", //Configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!")) //Configuration["JwtSettings:Key"]
                };
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobHunt.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        System.Array.Empty<string>()
                    }
                });
            });

           
        }

        public virtual void AddRepositoriesAndServices(IServiceCollection services)
        {
            //services.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReferenceDataService, ReferenceDataService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IStateRepository, StateRepository>();

            //services.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
            //services.RegisterType<QueryObject>().AsSelf().SingleInstance();
            //services.RegisterType<MovieReviewSchema>().AsSelf().SingleInstance();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobHunt.API v1");
            });
            //app.UseDeveloperExceptionPage();
            app.UseCors("AllowOrigin");
            //app.UseGraphQL<MovieReviewSchema>();
            // Enables Altair UI at path /
            //app.UseGraphQLAltair(new GraphQLAltairOptions {Path = "/"});
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Initialize(app);
        }

        private IApplicationBuilder Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IDatabaseSeeder>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }

    }
}