using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using busCompany.DATA;
using busCompany.DATA.Repository;
using busCompany.SERVICE.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<BusesSrvice>();
builder.Services.AddScoped<busCompany.Core.Entity.Route>();
builder.Services.AddScoped<Employee>();
builder.Services.AddScoped<PublicInquiries>();
builder.Services.AddScoped<Station>();
builder.Services.AddScoped<IRepositoryMamager, RepositoryManager>();

builder.Services.AddDbContext<DataContext>(option =>
    {
        option.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=bus-company;Integrated Security=true;");
    });
builder.Services.AddControllers().AddJsonOptions(options =>//dont be cycle
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });
builder.Services.AddControllers()//ignore the $id
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });
//service
builder.Services.AddScoped<IBusesService, BusesSrvice>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IRoutesService, RoutesService>();
builder.Services.AddScoped<IStationsService, StationsService>();
builder.Services.AddScoped<IPublicInquiriesService, PublicInquiriesService>();
//repository
builder.Services.AddScoped<IPublicInquiriesRepository, PublicInquiriesRepository>();
builder.Services.AddScoped<IStationRepository, StationsRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeesRepository>();
builder.Services.AddScoped<IRouteRepository, RoutesRepository>();
builder.Services.AddScoped<IBusesRepository, BusesRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
