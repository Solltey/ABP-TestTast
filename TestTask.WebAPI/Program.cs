using TestTask.Persistence;
using TestTesk.Application.Interfaces;
using TestTesk.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddSingleton<IDeviceRepository, DeviceRepository>(sp => {
    return new DeviceRepository(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<IExperimentRepository, ExperimentRepository>(sp => {
    return new ExperimentRepository(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<IChanceBasedOutputService, ChanceBasedOutputService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
