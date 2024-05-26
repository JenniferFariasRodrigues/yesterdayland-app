using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//To solve the serialize problem. Adds support for MVC controllers.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configure the framework and SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Enables support for exploiting API endpoints.
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
// Swagger configuration. Configure Swagger with information about the API.
builder.Services.AddSwaggerGen(c =>
{
    //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YesterdaylandAPI", Version = "v1" });
    //});
    //to solve UI swagger probmel-it not open on a web.
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "YesterdaylandAPI",
        Version = "v1",
        Description = "API for Yesterdayland Application",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@yesterdayland.com"
        }
    });
});

// Add CORS policy (optional, adjust as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Configure to use different ports
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenLocalhost(7020, listenOptions => listenOptions.UseHttps());
//    options.ListenLocalhost(5198);
//});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //  app.UseSwaggerUI();
    //app.UseSwagger();
    //using a swagger version to show the endpoint  
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "YesterdaylandAPI v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
// Apply the CORS policy

app.UseCors("AllowAll"); 

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");


app.Run();
