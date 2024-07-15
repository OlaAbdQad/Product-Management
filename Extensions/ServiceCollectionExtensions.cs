using Assessment_Task.Auth;
using Assessment_Task.Repository.Contracts;
using Assessment_Task.Repository.Implementations;
using Assessment_Task.Service.Contracts;
using Assessment_Task.Service.Implementations;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.GetSection("JwtSettings").Bind(jwtSettings);
        
        services.AddSingleton<IJwtManager>(new JwtManager(jwtSettings.Key));

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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        services.AddAuthorization();
        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        //- Update the connection string in the appsettings.development.json file to point to your local SQL Lite database.
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBlacklistedTokenService, BlacklistedTokenService>();
        return services;
    }
    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddTransient<IMapper, ServiceMapper>();
        return services;
    }
}
