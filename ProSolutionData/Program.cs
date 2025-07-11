using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ProSolutionData.Data;
using ProSolutionData.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add Services Here
builder.Services.AddScoped<DevolvedAreaPostCodeService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<CourseService>();


//Get connection string elements to asemble
var databaseSettings = builder.Configuration.GetSection("DatabaseConnection");
var server = databaseSettings["Server"];
var database = databaseSettings["Database"];
var useWindowsAuth = databaseSettings.GetValue<bool>("UseWindowsAuth");
var username = databaseSettings["Username"];
var password = databaseSettings["Password"];

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));

//Comment out for EF Core updates
var connectionStringExtra = "";
connectionStringExtra += "Server=" + server + ";";
connectionStringExtra += "Database=" + database + ";";
connectionStringExtra += "User ID=" + username + ";";
connectionStringExtra += "Password=" + password + ";";

//conStrBuilder.DataSource = server;
//conStrBuilder.InitialCatalog = database;

if (useWindowsAuth == true)
{
    conStrBuilder.IntegratedSecurity = useWindowsAuth;
}
else
{
    conStrBuilder.UserID = username;
    conStrBuilder.Password = password;
}
//End Comment out for EF Core updates

var connectionString = connectionStringExtra + conStrBuilder.ConnectionString;

Console.WriteLine(connectionString);
//Console.ReadKey();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


//Allow access from another URL
var APIEndpoint = builder.Configuration["APIEndpoint"] ?? "";

string? origins = "origins";
builder.Services.AddCors(options =>
    options.AddPolicy(origins,
        policy =>
        {
            policy.WithOrigins(APIEndpoint)
            .AllowAnyHeader()
            .AllowAnyMethod();
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("ProSolution Data API")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        //.WithPreferredScheme("ApiKey")
        //.WithApiKeyAuthentication(keyOptions => keyOptions.Token = "apikey");
    });
//}

app.UseHttpsRedirection();

app.UseCors(origins); //Enable cors access using URLs above

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
