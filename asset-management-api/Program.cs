using AssetManagement.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;


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
    services.AddSwaggerGen();

    services.AddScoped<IAssetManageRepo, SqlAssetManagerRepo>();
    services.AddDbContext<AssetContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DockerAssetConnection")));
    // services.AddDbContext<AssetContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AssetConnection")));
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
                       .AllowAnyMethod();
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

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}