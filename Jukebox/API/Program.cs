using Jukebox.DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Jukebox.DAL.Repositories;
using Jukebox.Models.Repositories;
using Jukebox.BLL.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
.AddXmlDataContractSerializerFormatters();  // api xml support

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(setupAction =>
{
    // Swagger xml documentation
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml.";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);

    // Authentication
    setupAction.AddSecurityDefinition("JukeboxApiBearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this API"
    });

    setupAction.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JukeboxApiBearerAuth" 
                }
            }, new List<string>() 
        }
    });
    // END Authentication

});


// DB Context
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

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeAuthenticated", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
    // todo: only band members can vote to rank their songlist
    //options.AddPolicy("MustBeBandmember", policy =>
    //{
    //    policy.RequireAuthenticatedUser();
    //    policy.RequireClaim("member", "true");
    //});
});

// Regular Dependency Injection classes
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.Run();



// Add API tests
// Add Unit tests
// Code UI
// Deploy
