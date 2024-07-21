using Services.Interfaces;
using Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

//Creating and Building the Web Application
var builder = WebApplication.CreateBuilder(args);//creating a WebApplicationBuilder instance

// Add services to the DI container.
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection")));
builder.Services.AddTransient<IEmployeeService, EmployeeServices>();// Employee service
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();// Employee Repository
builder.Services.AddTransient<IRoleService, RoleServices>();// Role service
builder.Services.AddTransient<IRoleRepository, RolesRepository>();// Role Repository
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //Checks if the application is running in the development environment
{
    app.UseSwagger();//Adds the Swagger JSON endpoint to the middleware pipeline. This endpoint exposes the API documentation in JSON format.
    app.UseSwaggerUI();//Adds Swagger UI 
}


//app.UseHttpsRedirection();//Redirects HTTP requests to HTTPS
app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();//It's used to restrict access to certain endpoints based on user rules or permissions.

app.MapControllers();//This method maps controller routes to the incoming HTTP requests.

app.Run();
