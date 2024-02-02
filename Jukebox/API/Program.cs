using Jukebox.DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Jukebox.DAL.Repositories;
using Jukebox.Models.Repositories;
using Jukebox.BLL.Interfaces;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/jukebox.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

/************************** Add services to the container. *************************************/

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml.";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddDbContext<JukeboxContext>(
    DbContextOptions => DbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:JukeboxDBConnectionString"],
        b => b.MigrationsAssembly("Jukebox.DAL")));


builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPerformerRespository, PerformerRespository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();

/********************** Build ****************************************************************/

var app = builder.Build();

/********************** Add Middleware *******************************************************/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
