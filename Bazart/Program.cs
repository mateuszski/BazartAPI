using System.Reflection;
using Bazart.API.Middleware;
using Bazart.DataAccess.Data;
using Bazart.DataAccess.Seeder;
using Bazart.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
//todo:NLOG
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddDbContext<BazartDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddScoped<BazartSeeder>();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddMvcCore();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<BazartSeeder>();

seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(conf =>
    {
        conf.SwaggerEndpoint("/swagger/v1/swagger.json", "BazartAPI");
    });
}
app.UseRouting();
app.UseCors(opt => 
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});

app.UseMiddleware<ErrorHandlingMiddleware>();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();