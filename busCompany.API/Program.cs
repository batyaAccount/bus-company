using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using busCompany.DATA;
using busCompany.DATA.Repository;
using busCompany.SERVICE.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<BusesSrvice>();
builder.Services.AddScoped<busCompany.Core.Entity.Route>();
builder.Services.AddScoped<Employee>();
builder.Services.AddScoped<PublicInquiries>();
builder.Services.AddScoped<Station>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<IBusesService, BusesSrvice>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IRoutesService, RoutesService>();
builder.Services.AddScoped<IStationsService, StationsService>();
builder.Services.AddScoped<IPublicInquiriesService, PublicInquiriesService>();
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