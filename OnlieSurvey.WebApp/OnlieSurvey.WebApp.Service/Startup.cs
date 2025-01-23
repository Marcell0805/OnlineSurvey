using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineSurvey.Repos;
using OnlineSurvey.Services.Contract;
using OnlineSurvey.Services.Implementation;
using OnlineSurvey.WebApp.Service.Settings;
using Serilog;

namespace OnlineSurvey.WebApp.Service
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configRoot = builder.Build();

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        private AppSettings AppSettings { get; }

        public IConfiguration Configuration { get; }
        public void Configure(IWebHostEnvironment webHostEnvironmentm, WebApplication webApplication)
        {
            if (!CheckDb())
            {
                UpdateDatabase(webApplication);
            }
            // Configure the HTTP request pipeline.
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }
            webApplication.UseCors(options =>
                options.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            webApplication.UseHttpsRedirection();
            webApplication.UseCors(cors => cors
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );

            webApplication.UseAuthorization();

            webApplication.MapControllers();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = configRoot.GetConnectionString();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InMemoryDb")));

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            //services.AddScoped<IEmpRepository, EmpRepository>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public static bool CheckDb()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            return dbContext.Database.CanConnect();
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            try
            {
                context.Database.Migrate();
            }
            catch (Exception)
            {


            }
        }
    }
}
