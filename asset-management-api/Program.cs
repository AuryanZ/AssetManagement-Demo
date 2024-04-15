using AssetManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
ConfigureServices(services);

var app = builder.Build();
var appEnvironment = app.Environment;

// Configure the HTTP request pipeline.
Configure(app, appEnvironment);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers().AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });
    services.AddEndpointsApiExplorer();


    // services.AddDbContext<AssetContext>(opt =>
    services.AddDbContext<AssetContext>(opt =>
    {
        // opt.UseSqlServer(builder.Configuration.GetConnectionString("DockerAssetConnection-office") ??
        //     throw new InvalidOperationException("Connection string is null")); // connection string to local docker-compose sql server
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DockerAssetConnection-home") ??
            throw new InvalidOperationException("Connection string is null")); // connection string to local docker-compose sql server

        // opt.UseSqlServer(builder.Configuration.GetConnectionString("WilliamNAS") ?? 
        //     throw new InvalidOperationException("Connection string is null")); // connection string use for NAS

        // opt.UseSqlServer(builder.Configuration.GetConnectionString("billNAS") ?? 
        //     throw new InvalidOperationException("Connection string is null")); // connection string use for remote connet to NAS

        // opt.UseSqlServer(builder.Configuration.GetConnectionString("AssetConnection") ?? 
        //     throw new InvalidOperationException("Connection string is null")); // connection string to local sql server
    });

    //Add Identity & JWT authentication
    //Identity
    services.AddIdentity<AppUser, IdentityRole>(opt =>
    {
        opt.Password.RequiredLength = 5;
        opt.Password.RequireDigit = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
    })
        .AddEntityFrameworkStores<AssetContext>()
        .AddSignInManager()
        .AddRoles<IdentityRole>();

    //JWT
    services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
        };
    });

    //Add authentication to Swagger UI
    services.AddSwaggerGen(opt =>
    {
        opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
    });

    services.AddScoped<IAccountRepo, SqlAccountRepo>();
    services.AddScoped<IAssetManageRepo, SqlAssetManagerRepo>();
    services.AddScoped<ITransformerRepo, SqlTransformerRepo>();
    // services.AddScoped<ISubstationRepo, SqlSubstationRepo>();
    services.AddScoped<IAssetGroupRepo, SqlAssetsGroupRepo>();

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // Add CORS policy
    // This is for development only
    // In production, you should only allow specific origins.
    // See https://docs.microsoft.com/aspnet/core/security/cors
    services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .WithExposedHeaders("Authorization", "refreshToken");
            });
    });
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("AllowSpecificOrigin");
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}